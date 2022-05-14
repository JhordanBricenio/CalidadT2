using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTest.Controllers
{
    public class LibroControllerTest
    {
        [Test]
        public void testDetails01() 
        {
            var mock= new Mock<ILibroRepository>();
            mock.Setup(m => m.ObtenerTodos(1)).Returns(new Libro() );
            var controller = new LibroController(mock.Object);
            var result = (ViewResult)controller.Details(1);
            Assert.IsNotNull(result);

           // Assert.AreEqual(1, ((List<Libro>)result.Model).Count);


        }

        [Test]
        public void AgregarComentario()
        {
            //Configurando el claims el cual es necesario para user
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });


            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext           
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);


            var mockIRepo = new Mock<ILibroRepository>();
            mockIRepo.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });


            var controller = new LibroController(mockIRepo.Object);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };

            var mock = new Mock<ILibroRepository>();
                mock.Setup(m => m.GuardarComentario(new Comentario()));
                mock.Setup(m => m.actualizar(new Comentario()));
            
            
            var result =controller.AddComentario(new Comentario());
            Assert.IsNotNull(result);

            // Assert.AreEqual(1, ((List<Libro>)result.Model).Count);


        }
    }
}
