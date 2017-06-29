using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRepositorio _repositorio;

        // GET: Produtos
        public ActionResult Index()
        {
            List<Produto> lstProdutos = new List<Produto>();
            _repositorio = new ProdutosRepositorio();

            lstProdutos = _repositorio.Produtos.Take(10).ToList();

            return View(lstProdutos);
        }
    }
}