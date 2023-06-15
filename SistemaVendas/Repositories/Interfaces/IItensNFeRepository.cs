using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IItensNFeRepository
    {
        Task<List<ItensNFeModel>> AllItensNFes();
        Task<ItensNFeModel> GetById(int id);
        Task<ItensNFeModel> Create(ItensNFeModel itensnfe);
        Task<ItensNFeModel> Update(ItensNFeModel itensnfe, int id);
        Task<bool> Delete(int id);
    }
}
