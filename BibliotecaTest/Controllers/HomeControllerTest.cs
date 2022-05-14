using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTest.Controllers
{
    public class HomeControllerTest
    {

        [Test]
        public void Index()
        {

            var mock = new Mock<IHomeRepository>();
            mock.Setup(o => o.ObtenerTodos()).Returns(new List<Libro> { new Libro() } );

            var controller = new HomeController(mock.Object);

            var result = (ViewResult)controller.Index();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, ((List<Libro>)result.Model).Count);
        }
    }
}
