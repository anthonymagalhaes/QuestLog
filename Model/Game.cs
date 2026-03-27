using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestLog.Model
{
    public class Game
    {
        [Key]
        public int id{get;set;}

        [Required]
        public string name{get;set;}
        
    }
}