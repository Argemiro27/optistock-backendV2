using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IProdutoVendaRepository
    {
        Task<List<ProdutoVendaModel>> AllProdutoVendas();
        Task<ProdutoVendaModel> GetById(int id);
        Task<ProdutoVendaModel> Create(ProdutoVendaModel produtovenda);
        Task<ProdutoVendaModel> Update(ProdutoVendaModel produtovenda, int id);
        Task<bool> Delete(int id);
    }
}
