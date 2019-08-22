using myadmin.Negocio.Processo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myadmin.Filters
{
    public class WebSiteAuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Se não tiver token
            if (filterContext.HttpContext.Session["TOKEN"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login");
            }
            else
            {
                String token = filterContext.HttpContext.Session["TOKEN"].ToString();

                BPLogin bp = new BPLogin();

                if (!bp.TokenEhValido(token) || !bp.UsuarioAtivo(token))
                {
                    filterContext.Result = new RedirectResult("~/Login");
                }
            }
        }

        private bool Authorize(HttpContextBase httpContext)
        {
            return true;
        }

    }
}