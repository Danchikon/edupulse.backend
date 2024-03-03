using EduPulse.Application.Abstractions;
using EduPulse.Application.Dtos;
using EduPulse.Application.Mediator.Commands.Groups;
using EduPulse.Application.Mediator.Commands.ScheduledEmails;
using EduPulse.Application.Mediator.Commands.Subjects;
using EduPulse.Application.Mediator.Commands.Teachers;
using EduPulse.Application.Mediator.Commands.Tests;
using EduPulse.Application.Mediator.Commands.UserAnswers;
using EduPulse.Application.Mediator.Commands.Users;
using MediatR;

namespace EduPulse.Api.GraphQl;

public class Mutation
{
    public async Task<UserAnswerDto> CreateUserAnswerAsync(
        CreateUserAnswerCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<SubjectDto> CreateSubjectAsync(
        CreateSubjectCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<ScheduledEmailDto> CreateScheduledEmailAsync(
        CreateScheduledEmailCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<bool> SendAsync(
        [Service] IEmailSender emailSender,
        CancellationToken cancellationToken
    )
    {
        await emailSender.SendEmailAsync(
            "example@example.com", 
            "daniel.hrovinsky@gmail.com", 
            "sub", 
            "bim",
            cancellationToken
            );
        
        return true;
    } 
    
    public async Task<TestDto> CreateTestAsync(
        CreateTestCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<bool> CreateStudentsAsync(
        CreateStudentCommand[] commands, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        await Task.WhenAll(commands.Select(command => mediator.Send(command, cancellationToken)));

        return true;
    } 
    
    public async Task<StudentDto> UpdateStudentAsync(
        UpdateStudentCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<TeacherDto> UpdateTeacherAsync(
        UpdateTeacherCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
    
    public async Task<bool> AddTeacherToGroupAsync(
        AddTeacherToGroupCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        await mediator.Send(command, cancellationToken);

        return true;
    } 
    
    public async Task<bool> AddTeacherToSubjectAsync(
        AddTeacherToSubjectCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        await mediator.Send(command, cancellationToken);

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
    
    public async Task<GroupDto> UpdateGroupAsync(
        UpdateGroupCommand command, 
        [Service] IMediator mediator,
        CancellationToken cancellationToken
    )
    {
        return await mediator.Send(command, cancellationToken);
    } 
}