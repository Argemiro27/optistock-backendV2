using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Repositories
{
    public class ProdutoVendaRepository : IProdutoVendaRepository
    {
        private readonly SistemaVendasDBContext _dbContext;
        public ProdutoVendaRepository(SistemaVendasDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<ProdutoVendaModel>> AllProdutoVendas()
        {
            return await _dbContext.ProdutoVendas.ToListAsync();
        }
        public async Task<ProdutoVendaModel> GetById(int id)
        {
            return await _dbContext.ProdutoVendas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<ProdutoVendaModel> Create(ProdutoVendaModel produtovenda)
        {
            await _dbContext.ProdutoVendas.AddAsync(produtovenda);
            await _dbContext.SaveChangesAsync();
            return produtovenda;
        }
        public async Task<ProdutoVendaModel> Update(ProdutoVendaModel produtovenda, int id)
        {
            ProdutoVendaModel produtovendaById = await GetById(id);
            if (produtovendaById == null)
            {
                throw new Exception($"ProdutoVenda para ID: {id} não encontrado!");
            }
            produtovendaById.id_produto = produtovenda.id_produto;
            produtovendaById.id_venda = produtovenda.id_venda;
            produtovendaById.quantidade = produtovenda.quantidade;

            _dbContext.ProdutoVendas.Update(produtovendaById);
            await _dbContext.SaveChangesAsync();

            return produtovendaById;
        }

        public async Task<bool> Delete(int id)
        {
            ProdutoVendaModel produtovendaById = await GetById(id);
            if (produtovendaById == null)
            {
                throw new Exception($"ProdutoVenda para ID: {id} não encontrado!");
            }

            _dbContext.ProdutoVendas.Remove(produtovendaById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

  
    }
}
