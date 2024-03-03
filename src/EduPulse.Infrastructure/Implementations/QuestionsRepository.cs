using System.Linq.Expressions;
using EduPulse.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace EduPulse.Infrastructure.Implementations;

public class QuestionsRepository<TDbContext> : EfRepository<QuestionEntity, TDbContext> where TDbContext : DbContext
{
    public QuestionsRepository(TDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public override async Task<QuestionEntity?> SingleOrDefaultAsync(
        Expression<Func<QuestionEntity, bool>> filter,
        CancellationToken cancellationToken = default
        )
    {
        var entity = await DbContext
            .Set<QuestionEntity>()
            .Include(question => question.Answers)
            .Where(filter)
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
        
        return entity;
    }
}