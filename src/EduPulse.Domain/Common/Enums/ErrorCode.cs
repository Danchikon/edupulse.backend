namespace EduPulse.Domain.Common.Errors;

public enum ErrorCode
{
    Unknown,
    NotFound,
    UserNotFound,
    UserWithSameEmailAlreadyExist,
    InvalidPassword,
    FavoriteAlreadyExist
}