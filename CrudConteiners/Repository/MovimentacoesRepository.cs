using CrudConteiners.Data;
using CrudConteiners.Interfaces;
using CrudConteiners.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudConteiners.Repository
{
    public class MovimentacoesRepository : IMovimentacoesRepository
    {
        private readonly CrudConteinerContext _context; 

        public MovimentacoesRepository(CrudConteinerContext context)
        {
            _context = context;
        }

        public async Task Create(Movimentacoes model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();  
        }

        public async Task<bool> Delete(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);

            if (movimentacao == null)
            {
                return false;
            }
            else 
            {
                _context.Remove(movimentacao);
                await _context.SaveChangesAsync();  
                return true;    
            }
        }

        public async Task<Movimentacoes> Get(int id)
        {
            var movimentacao = await _context.Movimentacoes.Include(m => m.Conteiner).FirstOrDefaultAsync(m => m.Id == id);

            return movimentacao;
        }

        public async Task<List<Movimentacoes>> GetAll()
        {
            var movimentacoes = await _context.Movimentacoes.Include(m => m.Conteiner).ToListAsync();

            return movimentacoes;
        }

        public async Task Update(Movimentacoes conteiner)
        {
            _context.Update(conteiner);
            await _context.SaveChangesAsync();
        }
    }
}
