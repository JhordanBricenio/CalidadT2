using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaTest.Controllers
{
    public class AuthControllerTest
    {

        [Test]
        public void logintest01()
        {
            var mock = new Mock<IAuthRepository>();
            var controlller = new AuthController(mock.Object);
            var result = controlller.Login();
            Assert.IsNotNull(result);

        }

        [Test]
        public void loginPostCase01NoValido()
        {

            var mockTipo = new Mock<IAuthRepository>();
                //mockTipo.Setup(o => o.aunteticacionCokie("admin", "123456")).Returns(false);
            var authControlller = new AuthController(mockTipo.Object);
            var result = authControlller.Login("admin", "123456");

            Assert.IsNotNull(result);
        }
    }
}
