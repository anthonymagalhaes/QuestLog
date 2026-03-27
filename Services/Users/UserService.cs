using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using QuestLog.Data;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using QuestLog.Mapping;
using QuestLog.Model;
using QuestLog.Repository;
using Microsoft.EntityFrameworkCore;

namespace QuestLog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly UserMapper _mapper;
        public UserService(IUserRepository repository, UserMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllUsersAsync();

            var usersDto = users.Select(u => _mapper.Map(u)).ToList();
            return usersDto;
        }

    }
}