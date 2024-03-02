using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Groups;
using EduPulse.Application.Mediator.Commands.Users;
using MediatR;

namespace EduPulse.Api.GraphQl;

public class Mutation
{
    public async Task<bool> CreateUsersAsync(
        CreateUserCommand[] commands, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        await Task.WhenAll(commands.Select(command => mediator.Send(command, cancellationToken)));

        return true;
    } 
    
    public async Task<GroupDto> CreateGroupAsync(
        CreateGroupCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
}