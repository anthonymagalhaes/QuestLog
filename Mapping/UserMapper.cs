using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using QuestLog.Model;

namespace QuestLog.Mapping
{
    public class UserMapper
    {
        public User Map(UserCreateDto dto , string criptedpassword)
        {
            return new User
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = criptedpassword
            };
        }

        public UserResponseDto Map(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                
            };
        }
    }
}