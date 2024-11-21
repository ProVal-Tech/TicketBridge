using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Octokit;
using Octokit.GraphQL;
using static Octokit.GraphQL.Variable;
using System.Security.Cryptography;
using System.Text;
using TicketBridge.Client.Services;

namespace TicketBridge.Services;

public class ServerGitHubService : IGitHubService {
    private string _clientId;
    private long _installationId;
    private DateTime _expiration;
    private GitHubClient _appClient;
    private Octokit.GraphQL.Connection? _installationClient;

    public ServerGitHubService(IConfiguration configuration) {
        string privateKeyPath = configuration["github:private_key_path"]
            ?? throw new ArgumentNullException(nameof(configuration), "The configuration entry github:private_key_path must be set.");
        _clientId = configuration["github:client_id"]
            ?? throw new ArgumentNullException(nameof(configuration), "The configuration entry github:client_id must be set.");
        if (long.TryParse(configuration["github:installation_id"], out _installationId) == false) {
            throw new ArgumentNullException(nameof(configuration), "The configuration entry github:installation_id must be set.");
        }

        string secretkey = File.ReadAllText(privateKeyPath);
        string token = GetJwtToken(secretkey, _clientId);
        _appClient = new(new Octokit.ProductHeaderValue("TicketBridge_GitHub")) {
            Credentials = new Credentials(token, AuthenticationType.Bearer)
        };
    }

    private async Task UpdateInstallationClient() {
        if (_installationClient is null || DateTime.UtcNow.AddMinutes(5) >= _expiration) {
            AccessToken accessToken = await _appClient.GitHubApps.CreateInstallationToken(_installationId);
            _expiration = accessToken.ExpiresAt.UtcDateTime;
            _installationClient = new(new Octokit.GraphQL.ProductHeaderValue("TicketBridge_GitHub"), accessToken.Token);
        }
        var query = new Query()
            .RepositoryOwner(Var("owner"))
            .Repository(Var("repo"))
            .Select(r => new {
                r.Name,
                r.Description
            }).Compile();
        var variables = new Dictionary<string, object> {
            { "owner", "proval-tech" },
            { "repo", "TicketBridge" },
        };
        var result = await _installationClient.Run(query, variables);
        Console.WriteLine(result.Name + result.Description);
    }

    public async Task<string> GetAppName() {
        await UpdateInstallationClient();
        var app = await _appClient.GitHubApps.GetCurrent();
        return app.Name;
    }

    private static string GetJwtToken(string secretKey, string issuer) {
        RSA rsaPk = RSA.Create();
        rsaPk.ImportFromPem(secretKey);
        RsaSecurityKey key = new(rsaPk);
        SigningCredentials credentials = new(key, SecurityAlgorithms.RsaSha256);
        SecurityTokenDescriptor descriptor = new() {
            Issuer = issuer,
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(9),
            SigningCredentials = credentials
        };
        JsonWebTokenHandler handler = new() { SetDefaultTimesOnTokenCreation = false };
        return handler.CreateToken(descriptor);
    }
}
