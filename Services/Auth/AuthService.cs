using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestLog.Data;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using QuestLog.DTOs.AuthDto;
using QuestLog.Mapping;
using QuestLog.Model;
using QuestLog.Services.Email;

namespace QuestLog.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly ITokenService _token;
        private readonly UserMapper _mapper;
        private readonly IEmailService _email;
        public AuthService(AuthDbContext context, ITokenService token, UserMapper mapper, IEmailService email)
        {
            _context = context;
            _token = token;
            _mapper = mapper;
            _email = email;
        }

        public async Task<UserResponseDto> RegisterAsync(UserCreateDto dto)
        {
            var criptedpassword = BCrypt.Net.BCrypt.HashPassword(dto.Senha, 12);
            var user = _mapper.Map(dto, criptedpassword);
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
            return await _token.GenerateToken(user);
        }

        public async Task RecoverAsync(RecoverAccountDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            Console.WriteLine(user);
            if (user != null)
            {
                try
                {
                    var token = await _token.GenerateResetToken(user);
                    Console.WriteLine(user.Email + user.Nome);
                    await _email.EmailRecover(user.Email, token, user.Nome);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao enviar e-mail de recuperação para {user.Email}: {ex}");
                }
            }
        }
        public async Task<string> ResetAsync(ResetPasswordDto dto)
        {
            var userId = await _token.ValidateAndConsumeToken(dto.Token);
            if (userId == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return null;
            }
            user.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha, 12);
            await _context.SaveChangesAsync();
            return await _token.GenerateToken(user);

        }
    }
}





