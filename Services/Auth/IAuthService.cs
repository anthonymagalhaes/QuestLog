using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using QuestLog.DTOs.AuthDto;
using Microsoft.AspNetCore.Mvc;

namespace QuestLog.Services
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(UserCreateDto dto);
        Task<string> LoginAsync(LoginRequestDto dto);

        Task RecoverAsync(RecoverAccountDto dto);
        Task<string> ResetAsync(ResetPasswordDto dto);
    }
}