using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public MarcaRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<MarcaModel>> AllMarcas()
        {
            return await _dbContext.Marcas.ToListAsync();
        }
        public async Task<MarcaModel> GetById(int id)
        {
            return await _dbContext.Marcas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<MarcaModel> Create(MarcaModel marca)
        {
            await _dbContext.Marcas.AddAsync(marca);
            await _dbContext.SaveChangesAsync();
            return marca;
        }
        public async Task<MarcaModel> Update(MarcaModel marca, int id)
        {
            MarcaModel marcaById = await GetById(id);
            if (marcaById == null)
            {
                throw new Exception($"Marca para ID: {id} não encontrado!");
            }
            marcaById.nome_marca = marca.nome_marca;
            marcaById.email = marca.email;
            marcaById.cnpj = marca.cnpj;
            marcaById.telefone = marca.telefone;

            _dbContext.Marcas.Update(marcaById);
            await _dbContext.SaveChangesAsync();

            return marcaById;
        }

        public async Task<bool> Delete(int id)
        {
            MarcaModel marcaById = await GetById(id);
            if (marcaById == null)
            {
                throw new Exception($"Marca para ID: {id} não encontrado!");
            }

            _dbContext.Marcas.Remove(marcaById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
