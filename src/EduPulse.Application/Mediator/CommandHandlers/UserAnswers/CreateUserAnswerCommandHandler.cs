using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.UserAnswers;
using EduPulse.Domain.Common;
using EduPulse.Domain.Entities;

namespace EduPulse.Application.Mediator.CommandHandlers.UserAnswers;

public class CreateUserAnswerCommandHandler : CommandHandlerBase<CreateUserAnswerCommand, UserAnswerDto>
{
    private readonly IRepository<UserAnswerEntity> _userAnswersRepository;
    private readonly IRepository<QuestionEntity> _questionsRepository;

    public CreateUserAnswerCommandHandler(
        IRepository<UserAnswerEntity> userAnswersRepository,
        IRepository<QuestionEntity> questionsRepository
        )
    {
        _userAnswersRepository = userAnswersRepository;
        _questionsRepository = questionsRepository;
    }

    public override async Task<UserAnswerDto> Handle(CreateUserAnswerCommand command, CancellationToken cancellationToken)
    {
        var questionEntity = await _questionsRepository.SingleAsync(question => question.Id == command.QuestionId, cancellationToken);

        var userAnswerEntity = new UserAnswerEntity
        {
            Id = Guid.NewGuid(),
            StudentId = command.StudentId,
            QuestionId = command.QuestionId,
            TestId = command.TestId,
            Points = questionEntity.Points,
            CorrectValue = questionEntity.Answers.Single(answer => answer.Id == questionEntity.CorrectAnswerId).Value,
            Value = command.Value
        };

        var userAnswerDto = await _userAnswersRepository.AddAsync<UserAnswerDto>(userAnswerEntity, cancellationToken);

        return userAnswerDto;
    }
}