using System.Web.Mvc;
using capaModelo.DTO;

namespace capaNegocios.Filtros
{
    public class AutorizarUsuario : ActionFilterAttribute
    {
        public int Rol { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = filterContext.HttpContext.Session["Usuario"] as UsuarioDTO;

            if (usuario == null)
            {
               
                filterContext.Result = new RedirectResult("~/Usuario/login");
                return;
            }

            if (!string.IsNullOrEmpty($"{Rol}"))
            {
                if (usuario.IdRol != Rol)
                {
                    filterContext.Result = new RedirectResult("~/Home/AccesoDenegado");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}