using EduPulse.Application.Dtos;
using EduPulse.Domain.Entities;
using EduPulse.Infrastructure.Persistence;
using Mapster;
using MapsterMapper;

namespace EduPulse.Api.GraphQl;

public class Query 
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ScheduledEmailDto> GetPagedScheduledEmails([Service] EduPulseDbContext dbContext)
    {
        return dbContext.ScheduledEmails.ProjectToType<ScheduledEmailDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ScheduledEmailDto> GetScheduledEmails([Service] EduPulseDbContext dbContext)
    {
        return dbContext.ScheduledEmails.ProjectToType<ScheduledEmailDto>();
    }
    
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<UserAnswerDto> GetPagedUserAnswers([Service] EduPulseDbContext dbContext)
    {
        return dbContext.UserAnswers.ProjectToType<UserAnswerDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<UserAnswerDto> GetUserAnswers([Service] EduPulseDbContext dbContext)
    {
        return dbContext.UserAnswers.ProjectToType<UserAnswerDto>();
    }
    
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<StudentDto> GetPagedStudents([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Students.ProjectToType<StudentDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<StudentDto> GetStudents([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Students.ProjectToType<StudentDto>();
    }
    
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TeacherDto> GetPagedTeachers([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Teachers.ProjectToType<TeacherDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TeacherDto> GetTeachers([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Teachers.ProjectToType<TeacherDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<InstituteDto> GetInstitutes([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Institutes.ProjectToType<InstituteDto>();
    }
    
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<GroupDto> GetPagedGroups([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Groups.ProjectToType<GroupDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<GroupDto> GetGroups([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Groups.ProjectToType<GroupDto>();
    }
    
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TestDto> GetPagedTests([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Tests.ProjectToType<TestDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TestDto> GetTests([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Tests.ProjectToType<TestDto>();
    }
    
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<SubjectDto> GetPagedSubjects([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Subjects.ProjectToType<SubjectDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<SubjectDto> GetSubjects([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Subjects.ProjectToType<SubjectDto>();
    }
}