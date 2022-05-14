using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CalidadT2.Repositorio
{
    public interface ILibroRepository
    {
        // Usuario aunteticacion(string username);
        Libro ObtenerTodos(int id);

        Usuario aunteticacion(string username);

        void GuardarComentario(Comentario comentario);


        void actualizar(Comentario comentario);
    }
    public class LibroRepositorio : ILibroRepository
    {
        private AppBibliotecaContext _dbEntities;
        public LibroRepositorio(AppBibliotecaContext dbEntities)
        {
            _dbEntities = dbEntities;
        }
        public Libro ObtenerTodos(int id)
        {
            return _dbEntities.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public Usuario aunteticacion(string username)
        {
            return _dbEntities.Usuarios.First(o => o.Username == username);
        }

        public void GuardarComentario(Comentario comentario)
        {
            _dbEntities.Comentarios.Add(comentario);
        }

        public void actualizar(Comentario comentario)
        {
            var libro = _dbEntities.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            _dbEntities.SaveChanges();
        }
    }
}
