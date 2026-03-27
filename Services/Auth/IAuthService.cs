using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;

namespace QuestLog.Services
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(UserCreateDto dto);
        Task<string> LoginAsync(LoginRequestDto dto);
    }
}