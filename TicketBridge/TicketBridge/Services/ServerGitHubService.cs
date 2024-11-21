using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Octokit;
using System.Security.Cryptography;
using System.Text;
using TicketBridge.Client.Services;

namespace TicketBridge.Services;

public class ServerGitHubService : IGitHubService {
    private GitHubClient _client;

    public ServerGitHubService(IConfiguration configuration) {
        string? privateKeyPath = configuration["github:private_key_path"];
        if (string.IsNullOrEmpty(privateKeyPath)) {
            throw new ArgumentNullException(nameof(configuration), "The configuration entry github:private_key_path must be set.");
        }
        string? clientId = configuration["github:client_id"];
        if (string.IsNullOrEmpty(clientId)) {
            throw new ArgumentNullException(nameof(configuration), "The configuration entry github:client_id must be set.");
        }
        string secretkey = File.ReadAllText(privateKeyPath);
        string token = GetJwtToken(secretkey, clientId);
        _client = new(new ProductHeaderValue("TicketBridge_GitHub")) {
            Credentials = new Credentials(token, AuthenticationType.Bearer)
        };
    }

    public async Task<string> GetAppName() {
        var app = await _client.GitHubApps.GetCurrent();
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
