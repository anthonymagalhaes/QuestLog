using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using QuestLog.DTOs.AuthDto;
using QuestLog.Model;
using QuestLog.Services;

namespace QuestLog.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var checkedUser = await _authService.LoginAsync(dto);

                return Ok(new { token = checkedUser });
            }
            catch (Exception err)
            {
                return BadRequest(new { message = "Erro ao efetuar login", error = err.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto dto)
        {
            try
            {
                var newUser = await _authService.RegisterAsync(dto);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao cadastrar usuário", error = ex.Message });
            }

        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] RecoverAccountDto dto)
        {
            try
            {
                await _authService.RecoverAsync(dto);
                return Ok("Se o email estiver cadastrado em nossa base, você receberá as instruções em instantes");
            }
            catch (Exception err)
            {
                return Ok(new { message = "Erro em recuperar conta, Tente novamente mais tarde", error = err.Message });
            }

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            try
            {
                var result =await _authService.ResetAsync(dto);
                return Ok(new { token = result });

            }
            catch (Exception err)
            {
                return Ok(new { message = "Erro no reset da senha, Tente Novamente",error = err.Message });
            }

        }
    }
}

