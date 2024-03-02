using EduPulse.Domain.Common.Enums;

namespace EduPulse.Domain.Common;

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