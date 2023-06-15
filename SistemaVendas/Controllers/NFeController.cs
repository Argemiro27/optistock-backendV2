using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Repositories;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFeController : ControllerBase
    {
        private readonly INFeRepository _nfeRepository;

        public NFeController(INFeRepository nfeRepository)
        {
            _nfeRepository = nfeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<NFeModel>>> AllNFes()
        {
            List<NFeModel> nfes = await _nfeRepository.AllNFes();
            return Ok(nfes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<NFeModel>>> GetById(int id)
        {
            NFeModel nfes = await _nfeRepository.GetById(id);
            return Ok(nfes);
        }
        [HttpPost]
        public async Task<ActionResult<NFeModel>> Create([FromBody] NFeModel nfeModel)
        {
            NFeModel nfe = await _nfeRepository.Create(nfeModel);
            return Ok(nfe);
        }

        [HttpPut("id")]
        public async Task<ActionResult<NFeModel>> Update([FromBody] NFeModel nfeModel, int id)
        {
            nfeModel.id = id;
            NFeModel nfe = await _nfeRepository.Update(nfeModel, id);
            return Ok(nfe);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<NFeModel>> Delete(int id)
        {
            bool deleted = await _nfeRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
