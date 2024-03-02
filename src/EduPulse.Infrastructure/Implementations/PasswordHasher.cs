using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using EduPulse.Application.Abstractions;
using EduPulse.Infrastructure.Options;

namespace EduPulse.Infrastructure.Implementations;

public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasherOptions _options;

    public PasswordHasher(IOptions<PasswordHasherOptions> options)
    {
        _options = options.Value;
    }

    public string Hash(string password)
    {
        var salt = Encoding.UTF8.GetBytes(_options.Salt);
        
        var hashedBytes = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: _options.IterationCount,
            numBytesRequested: 256 / 8
        );

        var hashed = Convert.ToBase64String(hashedBytes);
        
        return hashed;
    }
}