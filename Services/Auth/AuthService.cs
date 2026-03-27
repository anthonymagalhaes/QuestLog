using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using QuestLog.Data;
using QuestLog.Model;
using Microsoft.EntityFrameworkCore;
using QuestLog.Mapping;

namespace QuestLog.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly ITokenService _token;
        private readonly UserMapper _mapper;
        public AuthService(AuthDbContext context, ITokenService token,UserMapper mapper)
        {
            _context = context;
            _token = token;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> RegisterAsync(UserCreateDto dto)
        {
            var criptedpassword = BCrypt.Net.BCrypt.HashPassword(dto.Senha, 12);
            var user = _mapper.Map(dto,criptedpassword);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map(user);
        }

        public async Task<string> LoginAsync(LoginRequestDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                return null;
            }
            bool validpass = BCrypt.Net.BCrypt.Verify(dto.Senha, user.Senha);
            if (!validpass)
            {
                return null;
            }
            return _token.GenerateToken(user);
        }
    }
}
