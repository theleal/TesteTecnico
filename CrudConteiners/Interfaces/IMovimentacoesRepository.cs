using CrudConteiners.Models;

namespace CrudConteiners.Interfaces
{
    public interface IMovimentacoesRepository
    {
        Task<Movimentacoes> Get(int id);
        Task<List<Movimentacoes>> GetAll();
        Task Create(Movimentacoes model);
        Task Update(Movimentacoes conteiner);
        Task<bool> Delete(int id);
    }
}
