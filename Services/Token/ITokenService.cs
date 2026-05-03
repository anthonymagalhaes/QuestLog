using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Model;

namespace QuestLog.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
        Task<string> GenerateResetToken(User user);

        Task<int?> ValidateAndConsumeToken(string token);
    }
}