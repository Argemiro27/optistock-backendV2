using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Repositories;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoVendaController : ControllerBase
    {
        private readonly IProdutoVendaRepository _produtovendaRepository;

        public ProdutoVendaController(IProdutoVendaRepository produtovendaRepository)
        {
            _produtovendaRepository = produtovendaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoVendaModel>>> AllProdutoVendas()
        {
            List<ProdutoVendaModel> produtovendas = await _produtovendaRepository.AllProdutoVendas();
            return Ok(produtovendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutoVendaModel>>> GetById(int id)
        {
            ProdutoVendaModel produtovendas = await _produtovendaRepository.GetById(id);
            return Ok(produtovendas);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoVendaModel>> Create([FromBody] ProdutoVendaModel produtovendaModel)
        {
            ProdutoVendaModel produtovenda = await _produtovendaRepository.Create(produtovendaModel);
            return Ok(produtovenda);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ProdutoVendaModel>> Update([FromBody] ProdutoVendaModel produtovendaModel, int id)
        {
            produtovendaModel.id = id;
            ProdutoVendaModel produtovenda = await _produtovendaRepository.Update(produtovendaModel, id);
            return Ok(produtovenda);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<ProdutoVendaModel>> Delete(int id)
        {
            bool deleted = await _produtovendaRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
