using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace QuestLog.DTOs.Noticia
{
    public class NoticiaRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlImage {get;set;}
    }
}