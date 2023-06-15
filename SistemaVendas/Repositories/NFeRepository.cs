using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class NFeRepository : INFeRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public NFeRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<NFeModel>> AllNFes()
        {
            return await _dbContext.NFes.ToListAsync();
        }
        public async Task<NFeModel> GetById(int id)
        {
            return await _dbContext.NFes.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<NFeModel> Create(NFeModel nfe)
        {
            await _dbContext.NFes.AddAsync(nfe);
            await _dbContext.SaveChangesAsync();
            return nfe;
        }
        public async Task<NFeModel> Update(NFeModel nfe, int id)
        {
            NFeModel nfeById = await GetById(id);
            if (nfeById == null)
            {
                throw new Exception($"NFe para ID: {id} não encontrado!");
            }
            nfeById.id_distribuidora = nfe.id_distribuidora;
            nfeById.num_nfe = nfe.num_nfe;
            nfeById.total_icms = nfe.total_icms;
            nfeById.total_ipi = nfe.total_ipi;
            nfeById.total_pis = nfe.total_pis;
            nfeById.total_cofins = nfe.total_cofins;
            nfeById.total_iss = nfe.total_iss;
            nfeById.valortotal_nfe = nfe.valortotal_nfe;

            _dbContext.NFes.Update(nfeById);
            await _dbContext.SaveChangesAsync();

            return nfeById;
        }

        public async Task<bool> Delete(int id)
        {
            NFeModel nfeById = await GetById(id);
            if (nfeById == null)
            {
                throw new Exception($"NFe para ID: {id} não encontrado!");
            }

            _dbContext.NFes.Remove(nfeById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
