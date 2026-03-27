using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Data;

using QuestLog.Repository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using QuestLog.DTOs.Noticia;
using QuestLog.Mapping;
using QuestLog.Dto.UserDto;

namespace QuestLog.Services.Noticia
{
    public class NoticiaService : INoticiaService
    {
        private readonly INoticiaRepository _repository;
        private readonly NoticiaMapper _mapper;

        public NoticiaService(INoticiaRepository repository, NoticiaMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NoticiaResponseDto> Create(NoticiaRequestDto dto)
        {
            var noticia = _mapper.Map(dto);
            var noticiaCriada = await _repository.Create(noticia);
            if (noticiaCriada == null) return null;
            return _mapper.Map(noticiaCriada); 
        }
        
        public async Task<NoticiaResponseDto> Edit(NoticiaRequestDto dto, int id)
        {
            if(dto ==null || id <=0) return null;
            var noticiaExistente = await _repository.GetById(id);
            if( noticiaExistente == null)return null;
            var noticia = _mapper.Map(dto, noticiaExistente);
            await _repository.Edit(noticia);
            return _mapper.Map(noticia);
        }
        public async Task<NoticiaResponseDto> Delete(int id)
        {
            var noticia = await _repository.SoftDelete(id);
            if(noticia == null)return null;
            return _mapper.Map(noticia);
        }
        public async Task<NoticiaResponseDto> GetById(int id)
        {
            var noticia = await _repository.GetById(id);
            if (noticia == null) return null;
            return _mapper.Map(noticia);
        }

        public async Task<IEnumerable<NoticiaResponseDto>> GetAll()
        {
            var noticias = await _repository.GetAll();

            var response = noticias.Select(n => _mapper.Map(n)).ToList();
            return response;
        }



    }
}