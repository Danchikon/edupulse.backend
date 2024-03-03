using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Tests;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;
using EduPulse.Domain.Enums;

namespace EduPulse.Application.Mediator.CommandHandlers.Tests;

public class CreateTestCommandHandler : CommandHandlerBase<CreateTestCommand, TestDto>
{
    private readonly IRepository<TestEntity> _testsRepository;
    private readonly ITestScheduler _testScheduler;

    public CreateTestCommandHandler(
        IRepository<TestEntity> testsRepository,
        ITestScheduler testScheduler
        )
    {
        _testsRepository = testsRepository;
        _testScheduler = testScheduler;
    }

    public override async Task<TestDto> Handle(CreateTestCommand command, CancellationToken cancellationToken)
    {
        var testId = Guid.NewGuid();
        var createdAt = DateTimeOffset.UtcNow;
        
        var testEntity = new TestEntity
        {
            Id = testId,
            Title = command.Title,
            Description = command.Description,
            OpensAt = command.OpensAt,
            ClosesAt = command.ClosesAt,
            Status = TestStatus.Scheduled,
            CreatedAt = createdAt,
            Questions = command.CreateQuestionCommands.Select(createQuestionCommand =>
            {
                var answerEntities = createQuestionCommand.CreateAnswerCommands.Select(createAnswerCommand => new AnswerEntity
                {
                    Id = Guid.NewGuid(),
                    Value = createAnswerCommand.Value
                }).ToList();

                var correctAnswerId = answerEntities.Single(answer => answer.Value == createQuestionCommand.CreateCorrectAnswerCommand.Value).Id;

                var questionEntity = new QuestionEntity
                {
                    Id = Guid.NewGuid(),
                    Points = createQuestionCommand.Points,
                    Title = createQuestionCommand.Title,
                    Answers = answerEntities,
                    CorrectAnswerId = correctAnswerId
                };

                return questionEntity;
            }).ToList()
        };
        
        var testDto = await _testsRepository.AddAsync<TestDto>(testEntity, cancellationToken);

        await _testScheduler.ScheduleOpenAsync(testEntity.Id, testEntity.OpensAt, cancellationToken);
        await _testScheduler.ScheduleCloseAsync(testEntity.Id, testEntity.ClosesAt, cancellationToken);

        return testDto;
    }
}