using CalidadT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CalidadT2.Constantes;

namespace CalidadT2.Repositorio
{
    public interface IBibliotecaRepository
    {
        List<Biblioteca> ObtenerTodos(int id);
        void Guardar(Biblioteca biblioteca);
        
        Usuario ObtenerUsuario(Claim claim);


        Usuario aunteticacion(string username);

        void obtenerLeyendo(int id, int user);
        void obtenerTerminado(int id, int user);
    }
    public class BibliotecaRepositorio : IBibliotecaRepository
    {

        private AppBibliotecaContext _dbEntities;
        public BibliotecaRepositorio(AppBibliotecaContext dbEntities)
        {
            _dbEntities = dbEntities;
        }

 


        public void Guardar(Biblioteca biblioteca)
        {
            _dbEntities.Bibliotecas.Add(biblioteca);
            _dbEntities.SaveChanges();

        }

        public List<Biblioteca> ObtenerTodos(int id)
        {
            return _dbEntities.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == id)
                .ToList();
        }
        public Usuario aunteticacion(string username)
        {
            return _dbEntities.Usuarios.First(o => o.Username == username);
        }

        public Usuario ObtenerUsuario(Claim claim)
        {  
            return _dbEntities.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
        }
        
        public void obtenerLeyendo(int libroId, int user)
        {
            var libro = _dbEntities.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            _dbEntities.SaveChanges();
        }

        public void obtenerTerminado(int libroId, int user)
        {
            var libro = _dbEntities.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            _dbEntities.SaveChanges();

        }
    }
}
