using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestLog.DTOs.AuthDto
{
    public class ResetPasswordDto
    {
        public string Senha { get; set; }
        public string Token{get;set;}
    }
}