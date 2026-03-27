using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using QuestLog.Model;

namespace QuestLog.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    }
}