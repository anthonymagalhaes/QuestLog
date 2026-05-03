using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuestLog.Services.Email
{
    public interface IEmailService
    {
        public Task EmailRecover(string email, string token,string name);
        public Task SendEmail(string toName, string toEmail, string subject, string body, bool isHtml = false);
    }
}