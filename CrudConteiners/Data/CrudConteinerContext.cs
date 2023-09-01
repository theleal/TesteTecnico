using CrudConteiners.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudConteiners.Data
{
    public class CrudConteinerContext : DbContext
    {
        public CrudConteinerContext(DbContextOptions<CrudConteinerContext> options)  : base(options)
        {

        }

        public DbSet<Movimentacoes> Movimentacoes { get; set; } 
        public DbSet<Conteiner> Conteiners { get; set; }    
    }
}
