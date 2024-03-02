using EduPulse.Application.Abstractions;
using EduPulse.Application.Common.Mediator;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Users;
using EduPulse.Domain.Common;
using EduPulse.Domain.Common.Enums;
using EduPulse.Domain.Entities;
using MapsterMapper;

namespace EduPulse.Application.Mediator.CommandHandlers.Users;

public class UpdateUserCommandHandler : CommandHandlerBase<UpdateUserCommand, StudentDto>
{
    private readonly IRepository<StudentEntity> _usersRepository;

    public UpdateUserCommandHandler(IRepository<StudentEntity> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public override async Task<StudentDto> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var userEntity = await _usersRepository.SingleAsync(user => user.Id == command.Id, cancellationToken);

        userEntity.Email = command.Email;
        userEntity.FullName = command.FullName;
        userEntity.Age = command.Age;
        userEntity.PhoneNumber = command.PhoneNumber;
        userEntity.GroupId = command.GroupId;

        var userDto = await _usersRepository.UpdateAsync<StudentDto>(userEntity, cancellationToken);

        return userDto;
    }
}