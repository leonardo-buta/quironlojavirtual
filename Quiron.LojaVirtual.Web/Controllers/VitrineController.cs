using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 3;

        // GET: Vitrine
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            ProdutosViewModel produtosViewModel = new ProdutosViewModel();
            Paginacao paginacao = new Paginacao();
            _repositorio = new ProdutosRepositorio();
            
            // Monta a paginação
            paginacao.PaginaAtual = pagina;
            paginacao.ItensPorPagina = ProdutosPorPagina;
            paginacao.ItensTotal = _repositorio.Produtos.Count();

            // Monta os produtos
            produtosViewModel.Produtos = _repositorio.Produtos
                .Where(p => categoria == null || p.Categoria == categoria)
                .OrderBy(p => p.Descricao).Skip((pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina);
            produtosViewModel.Paginacao = paginacao;
            produtosViewModel.CategoriaAtual = categoria;

            return View(produtosViewModel);
        }
    }
}