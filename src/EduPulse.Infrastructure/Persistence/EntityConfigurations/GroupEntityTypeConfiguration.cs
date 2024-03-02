using EduPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPulse.Infrastructure.Persistence.EntityConfigurations;

public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<GroupEntity>
{
    public void Configure(EntityTypeBuilder<GroupEntity> builder)
    {
        builder.HasKey(group => group.Id);
        
        builder
            .HasIndex(group => group.Title)
            .HasMethod("btree");
    }
}