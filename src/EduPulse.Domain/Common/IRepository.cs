using System.Linq.Expressions;

namespace EduPulse.Domain.Common;

public interface IRepository<TEntity> 
{
    Task<TEntity> AddAsync(
        TEntity entity, 
        CancellationToken cancellationToken = default
        );
    
    Task<TDto> AddAsync<TDto>(
        TEntity entity, 
        CancellationToken cancellationToken = default
    );

    Task AddRangeAsync(
        ICollection<TEntity> entities,
        CancellationToken cancellationToken = default
    );
    
    Task<TEntity> UpdateAsync(
        TEntity entity, 
        CancellationToken cancellationToken = default
        );
    
    Task<TDto> UpdateAsync<TDto>(
        TEntity entity, 
        CancellationToken cancellationToken = default
    );
    
    Task RemoveAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
    );
    
    Task<TEntity> SingleAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        );
    Task<TEntity?> SingleOrDefaultAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        );
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> filter, 
        CancellationToken cancellationToken = default
        );
}