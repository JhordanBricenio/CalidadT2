using CalidadT2.Models;
using CalidadT2.Repositorio;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCuentaBancaria.Helpers;

namespace BibliotecaTest.Repositorio
{
    public class BibliotecaRepoTest
    {
        private static IQueryable<Biblioteca>? data;
        [SetUp]
        public void Setup()
        {
            data = new List<Biblioteca>
            {
                new Biblioteca { Id = 1, UsuarioId = 1 },
                new Biblioteca { Id = 2, UsuarioId = 1 },

            }.AsQueryable();
        }
        [Test]
        public void Guardar()
        {
            var mockBdSetBiblioteca = new MockDbSet<Biblioteca>(data);



            var mockBd = new Mock<AppBibliotecaContext>();
            mockBd.Setup(x => x.Bibliotecas).Returns(mockBdSetBiblioteca.Object);

            var cuentaRepo = new BibliotecaRepositorio(mockBd.Object);

             cuentaRepo.Guardar(new Biblioteca());

            Assert.AreEqual(2, data.Count());
        }

        [Test]
        public void ObtenerTodos()
        {
            var mockBdSetBiblioteca = new MockDbSet<Biblioteca>(data);



            var mockBd = new Mock<AppBibliotecaContext>();
            mockBd.Setup(x => x.Bibliotecas).Returns(mockBdSetBiblioteca.Object);

            var cuentaRepo = new BibliotecaRepositorio(mockBd.Object);

           var result= cuentaRepo.ObtenerTodos(1);

            Assert.AreEqual(2, data.Count());
        }


        [Test]
        public void ObtenerLeyendo()
        {
            var mockBdSetBiblioteca = new MockDbSet<Biblioteca>(data);



            var mockBd = new Mock<AppBibliotecaContext>();
            mockBd.Setup(x => x.Bibliotecas).Returns(mockBdSetBiblioteca.Object);

            var cuentaRepo = new BibliotecaRepositorio(mockBd.Object);
            cuentaRepo.obtenerLeyendo(1, 1);

            Assert.AreEqual(2, data.Count());
        }
    }
}
