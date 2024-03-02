using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace EduPulse.Infrastructure.Implementations;

public class JsonWebTokenService(
    JsonWebTokenHandler tokenHandler,
    [FromKeyedServices("jwt")] SigningCredentials signingCredentials
)
{
    public string Create(Dictionary<string, object>? claims = null)
    {
        var issuedAt = DateTime.UtcNow;
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            IssuedAt = issuedAt,
            Issuer = "edupulse",
            Audience = "edupulse",
            SigningCredentials = signingCredentials,
            Claims = claims
        };

        return tokenHandler.CreateToken(tokenDescriptor);
    }
}