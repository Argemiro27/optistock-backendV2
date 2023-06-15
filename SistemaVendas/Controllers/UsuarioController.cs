using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Repositories.Interfaces;

namespace SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> AllUsers() 
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.AllUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> GetById(int id)
        {
            UsuarioModel usuarios = await _usuarioRepository.GetById(id);
            return Ok(usuarios);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepository.Create(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("id")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.id = id;
            UsuarioModel usuario = await _usuarioRepository.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<UsuarioModel>> Delete(int id)
        {
            bool deleted = await _usuarioRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
