using System;
using System.Linq;
using System.Security.Claims;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepository app;

        public LibroController(ILibroRepository app)
        {
            this.app = app;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = app.ObtenerTodos(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            app.GuardarComentario(comentario);

            app.actualizar(comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            //var claim = HttpContext.User.Claims.FirstOrDefault();
            //var user = app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
           // return user;
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var username = claim.Value;
            return app.aunteticacion(username);
        }
    }
}
