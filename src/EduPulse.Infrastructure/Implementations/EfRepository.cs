using System.Linq.Expressions;
using EduPulse.Domain.Common.Errors;
using EduPulse.Domain.Common.Exceptions;
using EduPulse.Domain.Common.Repositories;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace EduPulse.Infrastructure.Implementations;

public class EfRepository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : class where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly IMapper _mapper;

    public EfRepository(
        TDbContext dbContext,
        IMapper mapper
        )
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TEntity> AddAsync(
        TEntity entity, 
        CancellationToken cancellationToken = default
        )
    {
        var entry = await _dbContext
            .Set<TEntity>()
            .AddAsync(entity, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task<TDto> AddAsync<TDto>(
        TEntity entity, 
        CancellationToken cancellationToken = default
    )
    {
        var updatedEntity = await AddAsync(entity, cancellationToken);

        return _mapper.Map<TDto>(updatedEntity);
    }

    public async Task AddRangeAsync(
        ICollection<TEntity> entities, 
        CancellationToken cancellationToken = default
    )
    {
        await _dbContext
            .Set<TEntity>()
            .AddRangeAsync(entities, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(
        TEntity entity, 
        CancellationToken cancellationToken = default
        )

    { 
        var entry = _dbContext
            .Set<TEntity>()
            .Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task<TDto> UpdateAsync<TDto>(TEntity entity, CancellationToken cancellationToken = default)
    {
        var updatedEntity = await UpdateAsync(entity, cancellationToken);

        return _mapper.Map<TDto>(updatedEntity);
    }

    public async Task RemoveAsync(
        Expression<Func<TEntity, bool>> where, 
        CancellationToken cancellationToken = default
        )
    {
        var entity = await SingleAsync(where, cancellationToken);

        _dbContext
            .Set<TEntity>()
            .Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> SingleAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        )
    {
        var entity = await SingleOrDefaultAsync(filter, cancellationToken);

        if (entity is null)
        {
            throw new BusinessException
            {
                ErrorCode = ErrorCode.NotFound,
                ErrorKind = ErrorKind.NotFound
            };
        }

        return entity;
    }

    public async Task<TEntity?> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        )
    {
        var entity = await _dbContext
            .Set<TEntity>()
            .Where(filter)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        
        return entity;
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        )
    {
        var any = await _dbContext
            .Set<TEntity>()
            .AnyAsync(filter, cancellationToken);
        
        return any;
    }
}