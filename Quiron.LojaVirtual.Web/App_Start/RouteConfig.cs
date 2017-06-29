using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 1 - Inicio
            // Mostra todos os produtos de todas as categorias

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Vitrine"
                    ,
                    action = "ListaProdutos"
                    ,
                    categoria = (string)null,
                    pagina = 1
                });


            // 2
            // Mostra todos os produtos de todas as categorias de uma página
            routes.MapRoute(null,
                "Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null
                },
                new { pagina = @"\d+" });


            //3
            // Mostra a categoria
            routes.MapRoute(null, "{categoria}", new
            {
                controller = "Vitrine",
                action = "ListaProdutos",
                pagina = 1
            });


            //4
            // Mostra a categoria e a página
            routes.MapRoute(null,
                "{categoria}/Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos"
                },
                new { pagina = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
