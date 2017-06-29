using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestsQuiron
    {
        [TestMethod]
        public void Take()
        {
            // O operador Take é usado para selecionar os primeiros n objetos de uma coleção

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int[] teste = { 5, 4, 1, 3, 9 };

            var resultado = from num in numeros.Take(5) select num;

            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()
        {

            // O operador skip ignora o(s) primerio(s) n objetos de uma coleção

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int[] teste = { 1, 3, 9 };

            var resultado = from num in numeros.Take(5).Skip(2) select num;

            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void TestarPaginacao()
        {
            // Arrange
            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao()
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };
            Func<int, string> paginaUrl = i => "Página" + i;

            // Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            // Assert
            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Página1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Página2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Página3"">3</a>", resultado.ToString());
        }
    }
}
