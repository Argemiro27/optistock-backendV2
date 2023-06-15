using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public ClienteRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<ClienteModel>> AllClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> GetById(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<ClienteModel> Create(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }
        public async Task<ClienteModel> Update(ClienteModel cliente, int id)
        {
            ClienteModel clienteById = await GetById(id);
            if (clienteById == null)
            {
                throw new Exception($"Cliente para ID: {id} não encontrado!");
            }
            clienteById.nome = cliente.nome;
            clienteById.email = cliente.email;
            clienteById.telefone = cliente.telefone;

            _dbContext.Clientes.Update(clienteById);
            await _dbContext.SaveChangesAsync();

            return clienteById;
        }

        public async Task<bool> Delete(int id)
        {
            ClienteModel clienteById = await GetById(id);
            if (clienteById == null)
            {
                throw new Exception($"Cliente para ID: {id} não encontrado!");
            }

            _dbContext.Clientes.Remove(clienteById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
