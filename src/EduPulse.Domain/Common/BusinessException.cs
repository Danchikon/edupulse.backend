using EduPulse.Domain.Common.Errors;

namespace EduPulse.Domain.Common.Exceptions;

public class BusinessException : Exception
{
    public required ErrorCode ErrorCode { get; init; }
    public required ErrorKind ErrorKind { get; init; }

    public BusinessException()
    {
        
    }

    public BusinessException(string message) : base(message)
    {
        
    }
}