using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestLog.Model;
using QuestLog.DTOs.Noticia;
using QuestLog.Services.Noticia;
using QuestLog.Dto.UserDto;

namespace QuestLog.controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly INoticiaService _service;
        public NoticiaController(INoticiaService service)
        {
            _service = service;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var noticia = await _service.GetById(id);
            if (noticia == null)
            {
                return NotFound();
            }
            return Ok(noticia);
        }
        
        [HttpGet("getall")]
         public async Task<ActionResult<IEnumerable<NoticiaResponseDto>>> GetAll()
       {
           try
           {
               var noticias = await _service.GetAll();
               return Ok(noticias);
           }catch(Exception ex)
           {
               return BadRequest(new {message = "Erro ao buscar usuários", error = ex.Message});
           }
       }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNoticia([FromBody] NoticiaRequestDto dto)
        {
            try
            {
                var noticia = await _service.Create(dto);
                if (noticia == null)
                {
                    return NotFound(new { message = "Erro ao Criar Noticia"});
                }
                return Created($"noticia/getbyid/{noticia.Id}", noticia);
            }
            catch (Exception err)
            {
                return BadRequest(new { message = "Erro ao Criar", error = err.Message });
            }
        }
        
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditNoticia([FromBody] NoticiaRequestDto dto,[FromRoute] int id)
        {
            try
            {
                var noticia = await _service.Edit(dto,id);
                if (noticia == null)
                {
                    return NotFound(new { message = "Erro ao Editar Noticia"});
                }
                return Created($"noticia/getbyid/{noticia.Id}", noticia);
            }
            catch (Exception err)
            {
                return BadRequest(new { message = "Erro ao Editar", error = err.Message });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNoticia([FromRoute] int id)
        {
            try
            {
                var noticia = await _service.Delete(id);
                if(noticia == null)
                {
                    return NotFound(new { message = "Erro ao Deletar Noticia"});
                }
                return Ok(noticia);
            }catch(Exception err)
            {
                return BadRequest(new { message = "Erro ao Deletar Noticia", error = err.Message });
            }
        }
    }
}