using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Timeouts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuestLog.Model
{
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Todas as noticias devem ter título")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "O título deve possuir de 10 até 150 caracteres")]

        public string Title { get; set; }

        [Required(ErrorMessage = "O conteúdo da notícia é obrigatório")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "O conteúdo deve possuir de 10 até 1000 caracteres")]
        public string Content { get; set; }
        public string? UrlImage {get;set;}
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsPublic { get; set; } = true;
        public int? UserId { get; set; }

        public int? CategoryId { get; set; }
        public int? GameId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [ForeignKey("GameId")]
        public virtual Game? Game { get; set; }

    }
}