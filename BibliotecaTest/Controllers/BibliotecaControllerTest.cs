using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
    public class BibliotecaControllerTest
    {
        [Test]
        public void IndexTest01()
        {

            //Configurando el claims el cual es necesario para user
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });


            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext           
                mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            
            var mockIRepo = new Mock<IBibliotecaRepository>();
                mockIRepo.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });
                mockIRepo.Setup(o => o.ObtenerTodos(1)).Returns(new List<Biblioteca>
                {
                    new Biblioteca()
                });


            var controller = new BibliotecaController(mockIRepo.Object);
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = mockContext.Object
                };
            var result = (ViewResult)controller.Index();
            Assert.IsNotNull(result);
            //Validamos que estamos esperando una cuenta como minimo
            Assert.AreEqual(1, ((List<Biblioteca>)result.Model).Count);
        }



        [Test]
        public void GuardarTest01()
        {
            var httpContext = new DefaultHttpContext();
            //Configurando el claims el cual es necesario para user
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });


            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext           
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);


            var mockIRepo = new Mock<IBibliotecaRepository>();
            mockIRepo.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });
            
            mockIRepo.Setup(o => o.Guardar(new Biblioteca()));
            
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["SessionVariable"] = "admin";

            var controller = new BibliotecaController(mockIRepo.Object)
            {
                TempData = tempData
            };
            
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var result =controller.Add(1);
            Assert.IsNotNull(result);
            //Validamos que estamos esperando una cuenta como minimo
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void MarcarComoleyendoTest01()
        {
            var httpContext = new DefaultHttpContext();
            //Configurando el claims el cual es necesario para user
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });


            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext           
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);


            var mockIRepo = new Mock<IBibliotecaRepository>();
            mockIRepo.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });


            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["SessionVariable"] = "admin";

            var controller = new BibliotecaController(mockIRepo.Object)
            {
                TempData = tempData
            };

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var result = controller.MarcarComoLeyendo(1);
            Assert.IsNotNull(result);
            //Validamos que estamos esperando una cuenta como minimo
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }



        [Test]
        public void MarcarComoTerminadoTest01()
        {
            var httpContext = new DefaultHttpContext();
            //Configurando el claims el cual es necesario para user
            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });


            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext           
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);


            var mockIRepo = new Mock<IBibliotecaRepository>();
            mockIRepo.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });


            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["SessionVariable"] = "admin";

            var controller = new BibliotecaController(mockIRepo.Object)
            {
                TempData = tempData
            };

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var result = controller.MarcarComoTerminado(1);
            Assert.IsNotNull(result);
            //Validamos que estamos esperando una cuenta como minimo
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }


    }
}
