using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Repositories;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> AllClientes()
        {
            List<ClienteModel> clientes = await _clienteRepository.AllClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ClienteModel>>> GetById(int id)
        {
            ClienteModel clientes = await _clienteRepository.GetById(id);
            return Ok(clientes);
        }
        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Create([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepository.Create(clienteModel);
            return Ok(cliente);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ClienteModel>> Update([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.id = id;
            ClienteModel cliente = await _clienteRepository.Update(clienteModel, id);
            return Ok(cliente);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<ClienteModel>> Delete(int id)
        {
            bool deleted = await _clienteRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
