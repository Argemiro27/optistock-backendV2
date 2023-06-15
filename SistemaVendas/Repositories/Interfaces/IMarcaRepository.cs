using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IMarcaRepository
    {
        Task<List<MarcaModel>> AllMarcas();
        Task<MarcaModel> GetById(int id);
        Task<MarcaModel> Create(MarcaModel marca);
        Task<MarcaModel> Update(MarcaModel marca, int id);
        Task<bool> Delete(int id);
    }
}
