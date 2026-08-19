using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using QuestLog.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuestLog.Services
{
    public class TokenService : ITokenService
    {
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration, IDistributedCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }

        public async Task<string> GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                SigningCredentials = signingCredentials,
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        public async Task<string> GenerateResetToken(User user)
        {
            var token = Guid.NewGuid().ToString("N");
            var cacheKey = $"pwd_reset:{token}";
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
            await _cache.SetStringAsync(cacheKey, user.Id.ToString(), options);

            return token;
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            ci.AddClaim(
            new Claim(ClaimTypes.Name, value: user.Nome));
            foreach (var role in user.Roles)
            {
                ci.AddClaim(new Claim(ClaimTypes.Role, value: role));
            }
            return ci;
        }

        public async Task<int?> ValidateAndConsumeToken(string token)
        {
            var cacheKey = $"pwd_reset:{token}";
            var userIdString = await _cache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(userIdString))
            {
                return null;
            }
            await _cache.RemoveAsync(cacheKey);
            return int.Parse(userIdString);
        }

    }
}