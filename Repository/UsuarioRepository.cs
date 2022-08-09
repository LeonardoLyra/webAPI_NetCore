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
        public void AdicionaUsuario(Usuario usuario)
        {
            _uContext.Add(usuario);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> BuscaUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> BuscaUsuarios()
        {
            throw new NotImplementedException();
        }

        public void DeletaUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}