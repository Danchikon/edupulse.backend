using System.Linq.Expressions;
using EduPulse.Domain.Common;
using EduPulse.Domain.Common.Enums;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace EduPulse.Infrastructure.Implementations;

public class EfRepository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : class where TDbContext : DbContext
{
    protected readonly TDbContext DbContext;
    private readonly IMapper _mapper;

    public EfRepository(
        TDbContext dbContext,
        IMapper mapper
        )
    {
        DbContext = dbContext;
        _mapper = mapper;
    }

    public virtual async Task<TEntity> AddAsync(
        TEntity entity, 
        CancellationToken cancellationToken = default
        )
    {
        var entry = await DbContext
            .Set<TEntity>()
            .AddAsync(entity, cancellationToken);
        
        await DbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public virtual async Task<TDto> AddAsync<TDto>(
        TEntity entity, 
        CancellationToken cancellationToken = default
    )
    {
        var updatedEntity = await AddAsync(entity, cancellationToken);

        return _mapper.Map<TDto>(updatedEntity);
    }

    public virtual async Task AddRangeAsync(
        ICollection<TEntity> entities, 
        CancellationToken cancellationToken = default
    )
    {
        await DbContext
            .Set<TEntity>()
            .AddRangeAsync(entities, cancellationToken);
        
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<TEntity> UpdateAsync(
        TEntity entity, 
        CancellationToken cancellationToken = default
        )

    { 
        var entry = DbContext
            .Set<TEntity>()
            .Update(entity);

        await DbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public virtual async Task<TDto> UpdateAsync<TDto>(TEntity entity, CancellationToken cancellationToken = default)
    {
        var updatedEntity = await UpdateAsync(entity, cancellationToken);

        return _mapper.Map<TDto>(updatedEntity);
    }

    public virtual async Task RemoveAsync(
        Expression<Func<TEntity, bool>> where, 
        CancellationToken cancellationToken = default
        )
    {
        var entity = await SingleAsync(where, cancellationToken);

        DbContext
            .Set<TEntity>()
            .Remove(entity);

        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<TEntity> SingleAsync(
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

    public virtual async Task<TEntity?> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        )
    {
        var entity = await DbContext
            .Set<TEntity>()
            .Where(filter)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        
        return entity;
    }

    public virtual async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        )
    {
        var any = await DbContext
            .Set<TEntity>()
            .AnyAsync(filter, cancellationToken);
        
        return any;
    }
}