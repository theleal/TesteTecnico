using CrudConteiners.Models;

namespace CrudConteiners.Interfaces
{
    public interface IConteinerRepository
    {
        Task<Conteiner> Get(int id);
        Task<List<Conteiner>> GetAll();
        Task Create(Conteiner model);
        Task Update(Conteiner conteiner);
        Task<bool> Delete(int id);
        Task<List<Movimentacoes>> GetMovimentacoesConteiner();

    }
}
