using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.DTOs.Noticia;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using QuestLog.Dto.UserDto;

namespace QuestLog.Services.Noticia
{
    public interface INoticiaService
    {
        Task<NoticiaResponseDto> GetById(int id);
        Task<IEnumerable<NoticiaResponseDto>> GetAll();

        Task<NoticiaResponseDto> Create(NoticiaRequestDto dto);
        Task<NoticiaResponseDto> Delete(int id);
        Task<NoticiaResponseDto> Edit(NoticiaRequestDto dto, int id);
    }
}