using SistemaVendas.Models;

namespace SistemaVendas.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> AllClientes();
        Task<ClienteModel> GetById(int id);
        Task<ClienteModel> Create(ClienteModel cliente);
        Task<ClienteModel> Update(ClienteModel cliente, int id);
        Task<bool> Delete(int id);
    }
}
