using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public VendaRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<VendaModel>> AllVendas()
        {
            return await _dbContext.Vendas.ToListAsync();
        }
        public async Task<VendaModel> GetById(int id)
        {
            return await _dbContext.Vendas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<VendaModel> Create(VendaModel venda)
        {
            await _dbContext.Vendas.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
            return venda;
        }
        public async Task<VendaModel> Update(VendaModel venda, int id)
        {
            VendaModel vendaById = await GetById(id);
            if (vendaById == null)
            {
                throw new Exception($"Venda para ID: {id} não encontrado!");
            }
            vendaById.id_cliente = venda.id_cliente;
            vendaById.data_venda = venda.data_venda;
            vendaById.precototal_venda = venda.precototal_venda;
            vendaById.metodo_pagamento = venda.metodo_pagamento;

            _dbContext.Vendas.Update(vendaById);
            await _dbContext.SaveChangesAsync();

            return vendaById;
        }

        public async Task<bool> Delete(int id)
        {
            VendaModel vendaById = await GetById(id);
            if (vendaById == null)
            {
                throw new Exception($"Venda para ID: {id} não encontrado!");
            }

            _dbContext.Vendas.Remove(vendaById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
