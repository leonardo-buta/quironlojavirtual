using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder sbResultado = new StringBuilder();
            TagBuilder tag = null;

            for (int count = 1; count <= paginacao.TotalPaginas; count++)
            {
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", paginaUrl(count));
                tag.InnerHtml = count.ToString();
                tag.AddCssClass(count == paginacao.PaginaAtual ? "btn btn-default btn-primary selected" : "btn btn-default");
                sbResultado.Append(tag);
            }

            return MvcHtmlString.Create(sbResultado.ToString());
        }
    }
}