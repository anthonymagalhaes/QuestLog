using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestLog.DTOs.Noticia
{
    public class NoticiaResponseDto
    {
        public int Id {get;set;}
        public string Title{get;set;}
        public string UrlImage{get;set;}
        public string Content{get;set;}
        public DateTime CreatedAt{get;set;}
        public bool IsPublic{get;set;}
    }
}