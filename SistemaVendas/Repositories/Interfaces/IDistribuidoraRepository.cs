using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IDistribuidoraRepository
    {
        Task<List<DistribuidoraModel>> AllDistribuidoras();
        Task<DistribuidoraModel> GetById(int id);
        Task<DistribuidoraModel> Create(DistribuidoraModel distribuidora);
        Task<DistribuidoraModel> Update(DistribuidoraModel distribuidora, int id);
        Task<bool> Delete(int id);
    }
}
