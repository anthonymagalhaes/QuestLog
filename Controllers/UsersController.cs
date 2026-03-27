using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Services;
using Microsoft.AspNetCore.Mvc;
using QuestLog.Model;
using QuestLog.Dto;
using QuestLog.Dto.UserDto;
using Microsoft.AspNetCore.Identity.Data;
using QuestLog.DTOs.Noticia;

namespace QuestLog.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public UsersController(IUserService userService)
        {
            _userService = userService;
      
        }

       [HttpGet]
       [Route("getall")]
       public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsers()
       {
           try
           {
               var users = await _userService.GetAllUsersAsync();
               return Ok(users);
           }catch(Exception ex)
           {
               return BadRequest(new {message = "Erro ao buscar usuários", error = ex.Message});
           }
       }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
               // var user = await _userService.GetUserByIdAsync(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(new {message = "Erro ao buscar usuário", error = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                // var user = await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao excluir usuário", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            try
            {
                // var newUser = await _userService.CreateUserAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao criar usuário", error = ex.Message });
            }
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
            try
            {
                // var updatedUser = await _userService.UpdateUserAsync(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar usuário", error = ex.Message });
            }
        }
    }

    
}