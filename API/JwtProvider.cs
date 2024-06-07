using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace API;

public static class JwtProvider
{
    public static async Task<string> GetJwt(Guid id, Guid userId, UserRoles role)
    {
        //Claim[] claims = [new("userId", id.ToString()), new("userRole", role.ToString())];
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, id.ToString()),
            new Claim("userId", userId.ToString()),
            new(ClaimsIdentity.DefaultRoleClaimType, role.ToString())
        };

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: "1kk$HAPPINESS",
            audience: "1kk$BUSINESS",
            notBefore: now,
            claims: claims,
            expires: now.Add(TimeSpan.FromDays(30)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                    "mm44turboshitpostmachine__sperma"u8.ToArray()),
                SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}