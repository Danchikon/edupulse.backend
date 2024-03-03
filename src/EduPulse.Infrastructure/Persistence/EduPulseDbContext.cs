using System.Reflection;
using System.Text;
using Bogus;
using EduPulse.Domain.Entities;
using EduPulse.Domain.Enums;
using EduPulse.Infrastructure.Entities;
using EduPulse.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace EduPulse.Infrastructure.Persistence;

public class EduPulseDbContext : DbContext
{
    public required DbSet<TeacherEntity> Teachers { get; init; }
    public required DbSet<StudentEntity> Students { get; init; }
    public required DbSet<InstituteEntity> Institutes { get; init; }
    public required DbSet<TeacherSubjectEntity> TeacherSubjects { get; init; }
    public required DbSet<TeacherGroupEntity> TeacherGroups { get; init; }
    public required DbSet<TestEntity> Tests { get; init; }
    public required DbSet<GroupEntity> Groups { get; init; }
    public required DbSet<SubjectEntity> Subjects { get; init; }
    
    public EduPulseDbContext(DbContextOptions<EduPulseDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<TestStatus>();
        
        modelBuilder
            .Entity<CentrifugoOutboxEntity>()
            .ToTable("centrifugo_outbox", tableBuilder => tableBuilder.ExcludeFromMigrations())
            .Property(outbox => outbox.Payload)
            .HasColumnType("jsonb");

        modelBuilder
            .Entity<InstituteEntity>()
            .HasData(new InstituteEntity[]
            {
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Адміністрування, державного управління та професійного розвитку інститут",
                    Code = "ІДА"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Архітектури та дизайну інститут",
                    Code = "ІАРД"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Будівництва та інженерних систем інститут",
                    Code = "ІБІС"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Геодезії інститут",
                    Code = "ІГДГ"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Гуманітарних та соціальних наук інститут",
                    Code = "ІГСН"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Економіки і менеджменту інститут",
                    Code = "ІНЕМ"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Енергетики та систем керування інститут",
                    Code = "ІЕСК"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Комп'ютерних наук та інформаційних технологій",
                    Code = "КНІ"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Комп'ютерних технологій, автоматики та метрології інститут",
                    Code = "ІКТА"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Механічної інженерії та транспорту інститут",
                    Code = "ІМІТ"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Права, психології та інноваційної освіти інститут",
                    Code = "ІППО"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Прикладної математики та фундаментальних наук інститут",
                    Code = "ІМФН"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Просторового планування та перспективних технологій інститут",
                    Code = "ІППТ"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Сталого розвитку і ім. В.Чорновола інститут",
                    Code = "ІСТР"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Телекомунікацій, радіоелектроніки та електронної техніки інститут",
                    Code = "ІТРЕ"
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Title = "Хімії та хімічних технологій інститут",
                    Code = "ІХХТ"
                },
            });
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}