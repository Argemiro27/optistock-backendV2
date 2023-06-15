using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class DistribuidoraRepository : IDistribuidoraRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public DistribuidoraRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<DistribuidoraModel>> AllDistribuidoras()
        {
            return await _dbContext.Distribuidoras.ToListAsync();
        }
        public async Task<DistribuidoraModel> GetById(int id)
        {
            return await _dbContext.Distribuidoras.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<DistribuidoraModel> Create(DistribuidoraModel distribuidora)
        {
            await _dbContext.Distribuidoras.AddAsync(distribuidora);
            await _dbContext.SaveChangesAsync();
            return distribuidora;
        }
        public async Task<DistribuidoraModel> Update(DistribuidoraModel distribuidora, int id)
        {
            DistribuidoraModel distribuidoraById = await GetById(id);
            if (distribuidoraById == null)
            {
                throw new Exception($"Distribuidora para ID: {id} não encontrado!");
            }
            distribuidoraById.nome_distribuidora = distribuidora.nome_distribuidora;
            distribuidoraById.cnpj = distribuidora.cnpj;
            distribuidoraById.cep = distribuidora.cep;
            distribuidoraById.telefone = distribuidora.telefone;
            distribuidoraById.email = distribuidora.email;

            _dbContext.Distribuidoras.Update(distribuidoraById);
            await _dbContext.SaveChangesAsync();

            return distribuidoraById;
        }

        public async Task<bool> Delete(int id)
        {
            DistribuidoraModel distribuidoraById = await GetById(id);
            if (distribuidoraById == null)
            {
                throw new Exception($"Distribuidora para ID: {id} não encontrado!");
            }

            _dbContext.Distribuidoras.Remove(distribuidoraById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
