using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        Task<List<VendaModel>> AllVendas();
        Task<VendaModel> GetById(int id);
        Task<VendaModel> Create(VendaModel venda);
        Task<VendaModel> Update(VendaModel venda, int id);
        Task<bool> Delete(int id);
    }
}
