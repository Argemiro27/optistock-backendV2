using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class ItensNFeRepository : IItensNFeRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public ItensNFeRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<ItensNFeModel>> AllItensNFes()
        {
            return await _dbContext.ItensNFes.ToListAsync();
        }
        public async Task<ItensNFeModel> GetById(int id)
        {
            return await _dbContext.ItensNFes.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<ItensNFeModel> Create(ItensNFeModel itensnfe)
        {
            await _dbContext.ItensNFes.AddAsync(itensnfe);
            await _dbContext.SaveChangesAsync();
            return itensnfe;
        }
        public async Task<ItensNFeModel> Update(ItensNFeModel itensnfe, int id)
        {
            ItensNFeModel itensnfeById = await GetById(id);
            if (itensnfeById == null)
            {
                throw new Exception($"ItensNFe para ID: {id} não encontrado!");
            }
            itensnfeById.id_produto = itensnfe.id_produto;
            itensnfeById.id_nfe = itensnfe.id_nfe;
            itensnfeById.quantidade = itensnfe.quantidade;
            itensnfeById.valor_unit = itensnfe.valor_unit;
            itensnfeById.valor_total_produto = itensnfe.valor_total_produto;
            itensnfeById.icms = itensnfe.icms;
            itensnfeById.ipi = itensnfe.ipi;
            itensnfeById.pis = itensnfe.pis;
            itensnfeById.cofins = itensnfe.cofins;
            itensnfeById.iss = itensnfe.iss;

            itensnfeById.total_icms_produto = itensnfe.total_icms_produto;
            itensnfeById.total_ipi_produto = itensnfe.total_ipi_produto;
            itensnfeById.total_pis_produto = itensnfe.total_pis_produto;
            itensnfeById.total_cofins_produto = itensnfe.total_cofins_produto;
            itensnfeById.total_iss_produto = itensnfe.total_iss_produto;

            _dbContext.ItensNFes.Update(itensnfeById);
            await _dbContext.SaveChangesAsync();

            return itensnfeById;
        }

        public async Task<bool> Delete(int id)
        {
            ItensNFeModel itensnfeById = await GetById(id);
            if (itensnfeById == null)
            {
                throw new Exception($"ItensNFe para ID: {id} não encontrado!");
            }

            _dbContext.ItensNFes.Remove(itensnfeById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
