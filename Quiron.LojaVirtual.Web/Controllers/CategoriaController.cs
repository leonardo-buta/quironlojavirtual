using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutosRepositorio _repositorio;

        /// <summary>
        /// Retorna uma Partial View com as categorias dos produtos
        /// </summary>
        public PartialViewResult Menu(string categoria = null)
        {
            _repositorio = new ProdutosRepositorio();
            IEnumerable<string> categorias;

            ViewBag.CategoriaSelecionada = categoria;

            categorias = _repositorio.Produtos
                .Select(c => c.Categoria)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categorias);
        }
    }
}