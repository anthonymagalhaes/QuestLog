using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Model;

namespace QuestLog.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}