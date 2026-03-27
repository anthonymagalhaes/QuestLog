using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestLog.Model
{
    public class Category
    {
        [Key]
        public int id{get;set;}

        [Required]
        public string name;
    }
}