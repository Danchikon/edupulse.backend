using System.Reflection;
using EduPulse.Domain.Entities;
using EduPulse.Domain.Enums;
using EduPulse.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPulse.Infrastructure.Persistence;

public class EduPulseDbContext : DbContext
{
    public required DbSet<UserEntity> Users { get; init; }
    public required DbSet<GroupEntity> Groups { get; init; }
    
    public EduPulseDbContext(DbContextOptions<EduPulseDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<UserRole>();
        
        modelBuilder
            .Entity<CentrifugoOutboxEntity>()
            .ToTable("centrifugo_outbox", tableBuilder => tableBuilder.ExcludeFromMigrations())
            .Property(outbox => outbox.Payload)
            .HasColumnType("jsonb");
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}