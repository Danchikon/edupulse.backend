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
    public IQueryable<UserDto> GetPagedUsers([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Users.ProjectToType<UserDto>();
    }
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<UserDto> GetUsers([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Users.ProjectToType<UserDto>();
    }
    
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<GroupDto> GetPagedGroups([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Groups.ProjectToType<GroupDto>();
    }
   
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<GroupDto> GetGroups([Service] EduPulseDbContext dbContext)
    {
        return dbContext.Groups.ProjectToType<GroupDto>();
    }
}