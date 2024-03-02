using EduPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPulse.Infrastructure.Persistence.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(user => user.Id);
        
        builder
            .HasIndex(user => user.FullName)
            .HasMethod("btree");
        
        builder
            .HasIndex(user => user.Email)
            .HasMethod("btree");
        
        builder
            .Property(user => user.Role)
            .HasColumnType("role");

        builder
            .HasMany(user => user.Groups)
            .WithMany(group => group.Users);
    }
}