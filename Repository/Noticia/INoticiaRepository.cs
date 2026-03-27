using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestLog.DTOs.Noticia;
using QuestLog.Model;

namespace QuestLog.Repository
{
    public interface INoticiaRepository
    {
        Task<Noticia> GetById(int id);
        Task<IEnumerable<Noticia>> GetAll();
        Task<Noticia> Create(Noticia noticia);
        Task<Noticia> Edit(Noticia noticia);
        Task<Noticia> HardDelete(int id);
        Task<Noticia> SoftDelete(int id);
    }
}