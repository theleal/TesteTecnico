using CrudConteiners.Data;
using CrudConteiners.Interfaces;
using CrudConteiners.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudConteiners.Repository
{
    public class ConteinerRepository : IConteinerRepository
    {
        private readonly CrudConteinerContext _context;

        public ConteinerRepository(CrudConteinerContext context)
        {
            _context = context;
        }
        public async Task Create(Conteiner model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var conteiner = await _context.Conteiners.FindAsync(id);
            if (conteiner == null)
            {
                return false;
            }
            else
            {
                _context.Remove(conteiner);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Conteiner> Get(int id)
        {
            var conteiner = await _context.Conteiners.FirstOrDefaultAsync(c => c.Id == id);

            return conteiner;
        }

        public async Task<List<Conteiner>> GetAll()
        {
            var conteiners = await _context.Conteiners.ToListAsync();

            return conteiners;
        }

        public async Task<List<Movimentacoes>> GetMovimentacoesConteiner()
        {
            var movimentacoes = await _context.Movimentacoes.Include(m => m.Conteiner).ToListAsync();   

            return movimentacoes;   
        }

        public async Task Update(Conteiner conteiner)
        {
            _context.Update(conteiner);
            await _context.SaveChangesAsync();
        }
    }
}
