using EduPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPulse.Infrastructure.Persistence.EntityConfigurations;

public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<TeacherEntity>
{
    public void Configure(EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.HasKey(teacher => teacher.Id);

        builder
            .HasMany(teacher => teacher.Subjects)
            .WithMany(subject => subject.Teachers)
            .UsingEntity<TeacherSubjectEntity>();
        
        builder
            .HasMany(teacher => teacher.Groups)
            .WithMany(group => group.Teachers)
            .UsingEntity<TeacherGroupEntity>();
    }
}