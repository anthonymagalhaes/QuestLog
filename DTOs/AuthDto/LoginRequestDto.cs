using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestLog.Dto.UserDto
{
    public class LoginRequestDto
    {
        public string Email{get;set;}
        public string Senha{get;set;}
    }
}