using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuestLog.Model
{
    public class User
    {
        [Key]
        public int Id{get;set;}

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome{get;set;}

        public string Email{get;set;}

        public string Senha{get;set;}
        public DateTime CreatedAt{get;set;} = DateTime.UtcNow;
        public DateTime? UpdatedAt{get;set;}

        public bool IsActive{get;set;} = true;

        public string[] Roles{get;set;} = ["Role_Padrao"];


    }
}