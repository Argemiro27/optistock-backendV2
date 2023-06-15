using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Repositories;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidoraController : ControllerBase
    {
        private readonly IDistribuidoraRepository _distribuidoraRepository;

        public DistribuidoraController(IDistribuidoraRepository distribuidoraRepository)
        {
            _distribuidoraRepository = distribuidoraRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<DistribuidoraModel>>> AllDistribuidoras()
        {
            List<DistribuidoraModel> distribuidoras = await _distribuidoraRepository.AllDistribuidoras();
            return Ok(distribuidoras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DistribuidoraModel>>> GetById(int id)
        {
            DistribuidoraModel distribuidoras = await _distribuidoraRepository.GetById(id);
            return Ok(distribuidoras);
        }
        [HttpPost]
        public async Task<ActionResult<DistribuidoraModel>> Create([FromBody] DistribuidoraModel distribuidoraModel)
        {
            DistribuidoraModel distribuidora = await _distribuidoraRepository.Create(distribuidoraModel);
            return Ok(distribuidora);
        }

        [HttpPut("id")]
        public async Task<ActionResult<DistribuidoraModel>> Update([FromBody] DistribuidoraModel distribuidoraModel, int id)
        {
            distribuidoraModel.id = id;
            DistribuidoraModel distribuidora = await _distribuidoraRepository.Update(distribuidoraModel, id);
            return Ok(distribuidora);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<DistribuidoraModel>> Delete(int id)
        {
            bool deleted = await _distribuidoraRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
