namespace EduPulse.Domain.Common.Enums;

public enum ErrorCode
{
    Unknown,
    NotFound,
    StudentWithSameEmailAlreadyExist,
    InvalidPassword,
    TeacherWithSameEmailAlreadyExist,
}