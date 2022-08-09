using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Repository;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _uRepo;

        public UsuarioController(IUsuarioRepository uRepo)
        {
            _uRepo = uRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscaUsuario(int id)
        {
            var usuario = await _uRepo.BuscaUsuario(id);

            return usuario != null ? Ok(usuario) : NotFound("Usuário não encontrado!");
        }

        [HttpGet]
        public async Task<IActionResult> BuscaUsuarios()
        {
            var usuarios = await _uRepo.BuscaUsuarios();

            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaUsuario(Usuario usuario)
        {
            _uRepo.AdicionaUsuario(usuario);
            return await _uRepo.SaveAsync() ? Ok("Usuário Adicionado com Sucesso!") : BadRequest("Erro ao Salvar Usuário!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaUsuario(int id, Usuario usuario)
        {
            var usu = await _uRepo.BuscaUsuario(id);

            if (usu == null) return NotFound("Usuário não encontrado!");

            usu.Nome = usuario.Nome ?? usu.Nome;
            usu.DataNascimento = usuario.DataNascimento != new DateTime() ? usuario.DataNascimento : usu.DataNascimento;

            _uRepo.AtualizaUsuario(usu);

            return await _uRepo.SaveAsync() ? Ok("Usuário Atualizado com Sucesso!") : BadRequest("Erro ao Atualizar Usuário!");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaUsuario(int id)
        {
            var usu = await _uRepo.BuscaUsuario(id);

            if (usu == null) return NotFound("Usuário não encontrado!");

            _uRepo.DeletaUsuario(usu);

            return await _uRepo.SaveAsync() ? Ok("Usuário Excluído com Sucesso!") : BadRequest("Erro ao Excluir Usuário!");

        }
    }
}