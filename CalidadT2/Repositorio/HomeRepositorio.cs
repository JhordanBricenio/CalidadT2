using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface IHomeRepository
    {
        // Usuario aunteticacion(string username);
        List<Libro> ObtenerTodos();
    }
    public class HomeRepositorio : IHomeRepository
    {
        private AppBibliotecaContext _dbEntities;
        public HomeRepositorio(AppBibliotecaContext dbEntities)
        {
            _dbEntities = dbEntities;
        }
        public List<Libro> ObtenerTodos()
        {
            return _dbEntities.Libros.Include(o => o.Autor).ToList();
        }
    }
}
