using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Groups;
using EduPulse.Application.Mediator.Commands.Tests;
using EduPulse.Application.Mediator.Commands.Users;
using MediatR;

namespace EduPulse.Api.GraphQl;

public class Mutation
{
    public async Task<TestDto> CreateTestAsync(
        CreateTestCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<bool> CreateUsersAsync(
        CreateUserCommand[] commands, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        await Task.WhenAll(commands.Select(command => mediator.Send(command, cancellationToken)));

        return true;
    } 
    
    public async Task<StudentDto> UpdateUserAsync(
        UpdateUserCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<GroupDto> CreateGroupAsync(
        CreateGroupCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<GroupDto> UpdateGroupAsync(
        UpdateGroupCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
}