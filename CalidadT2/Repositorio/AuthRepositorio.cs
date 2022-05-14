using CalidadT2.Models;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface IAuthRepository
    {
       // Usuario aunteticacion(string username);
        Usuario aunteticacionCokie(string username, string password);
    }
    public class AuthRepositorio : IAuthRepository
    {
        private AppBibliotecaContext _dbEntities;
        public AuthRepositorio(AppBibliotecaContext dbEntities)
        {
            _dbEntities = dbEntities;
        }
        public Usuario aunteticacionCokie(string username, string password)
        {
            return _dbEntities.Usuarios.Where(o => o.Username == username && o.Password == password).FirstOrDefault();
        }

      
    }
}
