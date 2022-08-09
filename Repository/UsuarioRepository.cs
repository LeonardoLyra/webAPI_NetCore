using Microsoft.EntityFrameworkCore;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _uContext;

        public UsuarioRepository(UsuarioContext uContext)
        {
            _uContext = uContext;
        }
        public async Task<Usuario> BuscaUsuario(int id)
        {
            return await _uContext.Usuarios.Where(usuario => usuario.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> BuscaUsuarios()
        {
            return await _uContext.Usuarios.OrderBy(u => u.Nome).ToListAsync();
        }

        public void AdicionaUsuario(Usuario usuario)
        {
            _uContext.Add(usuario);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            _uContext.Update(usuario);
        }

        public void DeletaUsuario(Usuario usuario)
        {
            _uContext.Remove(usuario);
        }

        public async Task<bool> SaveAsync()
        {
            return await _uContext.SaveChangesAsync() > 0;
        }
    }
}