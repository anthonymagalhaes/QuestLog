using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.DTOs.Noticia;
using QuestLog.Model;
using Microsoft.AspNetCore.Components.Web;

namespace QuestLog.Mapping
{
    public class NoticiaMapper
    {
        public Noticia Map(NoticiaRequestDto dto)
        {
            return new Noticia
            {
                Title = dto.Title,
                Content = dto.Content,
                UrlImage = dto.UrlImage
            };
        }
        public Noticia Map(NoticiaRequestDto dto,Noticia noticiaExistente)
        {
            if (dto == null || noticiaExistente == null) return noticiaExistente;
            noticiaExistente.Title = dto.Title;
            noticiaExistente.Content = dto.Content;
            noticiaExistente.UrlImage = dto.UrlImage;
            return noticiaExistente;
        }

        public NoticiaResponseDto Map(Noticia noticia)
        {
            return new NoticiaResponseDto
            {
                Id = noticia.Id,
                Title = noticia.Title,
                UrlImage = noticia.UrlImage,
                Content = noticia.Content,
                CreatedAt = noticia.CreatedAt,
                IsPublic = noticia.IsPublic,
            };
        }
    }
}