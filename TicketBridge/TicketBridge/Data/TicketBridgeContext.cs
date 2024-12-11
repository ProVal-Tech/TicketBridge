using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace TicketBridge.Data;

public class TicketBridgeContext : DbContext {
    public DbSet<GitHubIntegration> GitHubIntegrations { get; set; }

    public string DbPath = $"{AppContext.BaseDirectory}/TicketBridge.db";

    JsonSerializerOptions jsonOptions = new();
    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GitHubIntegration>()
            .Property(e => e.Properties)
            .HasConversion(
                v => JsonSerializer.Serialize(v, jsonOptions),
                v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, jsonOptions) ?? new Dictionary<string, string>()
            );
    }
}
