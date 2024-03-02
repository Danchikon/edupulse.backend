using EduPulse.Application.Dtos;

namespace EduPulse.Application.Abstractions;

public interface IFilesStorage
{
    Task<Uri> UploadAsync(
        FileDto file,
        string folder,
        string name,
        CancellationToken cancellationToken = default
    );
    
    Uri GetUri(
        string folder,
        string name
    );
    
    Task RemoveAsync(
        string folder,
        string name,
        CancellationToken cancellationToken = default
    );
}
