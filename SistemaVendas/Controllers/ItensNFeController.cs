using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Repositories;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensNFeController : ControllerBase
    {
        private readonly IItensNFeRepository _itensnfeRepository;

        public ItensNFeController(IItensNFeRepository itensnfeRepository)
        {
            _itensnfeRepository = itensnfeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ItensNFeModel>>> AllItensNFes()
        {
            List<ItensNFeModel> itensnfes = await _itensnfeRepository.AllItensNFes();
            return Ok(itensnfes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ItensNFeModel>>> GetById(int id)
        {
            ItensNFeModel itensnfes = await _itensnfeRepository.GetById(id);
            return Ok(itensnfes);
        }
        [HttpPost]
        public async Task<ActionResult<ItensNFeModel>> Create([FromBody] ItensNFeModel itensnfeModel)
        {
            ItensNFeModel itensnfe = await _itensnfeRepository.Create(itensnfeModel);
            return Ok(itensnfe);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ItensNFeModel>> Update([FromBody] ItensNFeModel itensnfeModel, int id)
        {
            itensnfeModel.id = id;
            ItensNFeModel itensnfe = await _itensnfeRepository.Update(itensnfeModel, id);
            return Ok(itensnfe);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<ItensNFeModel>> Delete(int id)
        {
            bool deleted = await _itensnfeRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
