using EduPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPulse.Infrastructure.Persistence.EntityConfigurations;

public class TestEntityTypeConfiguration : IEntityTypeConfiguration<TestEntity>
{
    public void Configure(EntityTypeBuilder<TestEntity> builder)
    {
        builder.HasKey(test => test.Id);
        
        builder
            .HasIndex(test => test.Title)
            .HasMethod("btree");

        builder
            .Property(test => test.Status)
            .HasColumnType("test_status");
    }
}