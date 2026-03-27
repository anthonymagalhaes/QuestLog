using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestLog.Model;
using QuestLog.Data;
using QuestLog.DTOs.Noticia;

namespace QuestLog.Repository
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly AuthDbContext _context;
        public NoticiaRepository(AuthDbContext context)
        {
            _context = context;
        }
        
        public async Task<Noticia> Create(Noticia noticia)
        {
            _context.Noticias.AddAsync(noticia);
            await _context.SaveChangesAsync();
            return noticia;
        }
        public async Task<Noticia> HardDelete(int id)
        {
            var noticia = await _context.Noticias.FirstOrDefaultAsync(x => id == x.Id);
            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();
            return noticia;
        }

        public async Task<Noticia> SoftDelete(int id)
        {
            var noticia = await _context.Noticias.FirstOrDefaultAsync(x => x.Id == id);
            if(noticia == null) return null;
            noticia.IsPublic = false;
            await _context.SaveChangesAsync();
            return noticia;
        }

        public async Task<Noticia> GetById(int id)
        {
            return await _context.Noticias.
            AsNoTracking().
            FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public async Task<IEnumerable<Noticia>> GetAll()
        {
            return await _context.Noticias.AsNoTracking().ToListAsync();
        }
        public async Task<Noticia> Edit(Noticia noticia)
        {
            _context.Noticias.Entry(noticia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return noticia;
        }
    }
}