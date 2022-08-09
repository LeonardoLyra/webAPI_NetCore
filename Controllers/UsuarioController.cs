using Microsoft.AspNetCore.Mvc;
using webAPI.Repository;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _uRepo;

        public UsuarioController(IUsuarioRepository uRepo)
        {
            _uRepo = uRepo;
        }
        [HttpGet]
        public string GetUser()
        {
            return "Hello World";
        }
    }
}