using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface INFeRepository
    {
        Task<List<NFeModel>> AllNFes();
        Task<NFeModel> GetById(int id);
        Task<NFeModel> Create(NFeModel nfe);
        Task<NFeModel> Update(NFeModel nfe, int id);
        Task<bool> Delete(int id);
    }
}
