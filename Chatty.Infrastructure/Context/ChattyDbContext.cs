using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatty.ApplicationCore.Entities;
using Chatty.ApplicationCore.Interfaces.Marker;

namespace Chatty.Infrastructure.Context;

public class ChattyDbContext : DbContext
{

    public DbSet<ChattyUser> ChattyUsers { get; set; }
    public DbSet<ChattyBrowserSession> ChattyBrowserSessions { get; set; }

    public DbSet<ChattySessionQrCode> ChattySessionQrCodes { get; set; }

    public ChattyDbContext(DbContextOptions<ChattyDbContext> options) : base(options)
    {

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {

        foreach (var entry in ChangeTracker.Entries())
        {

            if (entry.Entity is ISoftDeletable)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.GetType().GetProperty("Deleted")?.SetValue(entry.Entity, true);
                }
                else if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Entity.GetType().GetProperty("Deleted")?.SetValue(entry.Entity, false);
                }
            }

        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ChattyUser>(entitiy =>
        {
            entitiy.ToTable("chatty_users");
        });

        modelBuilder.Entity<ChattyBrowserSession>(entitiy =>
        {
            entitiy.ToTable("chatty_browser_sessions");
        });

        modelBuilder.Entity<ChattySessionQrCode>(entitiy =>
        {
            entitiy.ToTable("chatty_session_qr_code");
        });

    }

}