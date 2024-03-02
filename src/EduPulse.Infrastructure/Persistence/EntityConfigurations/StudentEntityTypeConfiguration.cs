using EduPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPulse.Infrastructure.Persistence.EntityConfigurations;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.HasKey(student => student.Id);
        
        builder
            .HasIndex(student => student.FullName)
            .HasMethod("btree");
        
        builder
            .HasIndex(student => student.Email)
            .HasMethod("btree");

        builder
            .HasOne(student => student.Group)
            .WithMany(group => group.Students)
            .HasForeignKey(student => student.GroupId);
    }
}