using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myadmin.Controllers
{
    public class BaseController : Controller
    {


        public virtual void AddMessage(String title, String message, String tipo, Boolean redirect = false)
        {
            if (!redirect)
            {
                ViewBag.Ativo = true;
                ViewBag.Titulo = title;
                ViewBag.Corpo = message;
                ViewBag.Tipo = tipo;
            }
            else
            {
                TempData["Ativo"] = true;
                TempData["Titulo"] = title;
                TempData["Corpo"] = message;
                TempData["Tipo"] = tipo;
            }
        }

        public virtual void AlertPanel(String Title, List<String> Messages)
        {
            ViewBag.PanelAlert_Ativo = true;
            ViewBag.PanelAlert_Titulo = Title;

            ViewBag.PanelAlert_Mensagem = "<ul>";
            foreach (String erro in Messages)
            {
                String erro_trat = erro.Replace("\r\n", "<br/>");
                erro_trat = erro.Replace("\"", "");
                ViewBag.PanelAlert_Mensagem = ViewBag.PanelAlert_Mensagem + String.Format("<li>{0}</li>", erro_trat);
            }
            ViewBag.PanelAlert_Mensagem = ViewBag.PanelAlert_Mensagem + "</ul>";
        }

        public virtual void AlertPanel(String Title, String Message)
        {
            String erro_trat = Message.Replace("\r\n", "<br/>");
            erro_trat = Message.Replace("\"", "");

            ViewBag.PanelAlert_Ativo = true;
            ViewBag.PanelAlert_Titulo = Title;
            ViewBag.PanelAlert_Mensagem = String.Format("<ul><li>{0}</li>", erro_trat);
        }
        public class BaseMessageController : Controller
        {
            public virtual void AddMessage(String title, String message, String tipo, Boolean redirect = false)
            {
                if (!redirect)
                {
                    ViewBag.Ativo = true;
                    ViewBag.Titulo = title;
                    ViewBag.Corpo = message;
                    ViewBag.Tipo = tipo;
                }
                else
                {
                    TempData["Ativo"] = true;
                    TempData["Titulo"] = title;
                    TempData["Corpo"] = message;
                    TempData["Tipo"] = tipo;
                }
            }

            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (TempData["Ativo"] != null)
                {
                    if ((Boolean)TempData["Ativo"] == true)
                    {
                        this.AddMessage((String)TempData["Titulo"], (String)TempData["Corpo"], (String)TempData["Tipo"]);
                        TempData["Ativo"] = null;
                        TempData["Titulo"] = null;
                        TempData["Corpo"] = null;
                    }
                }
                base.OnActionExecuting(filterContext);
            }
        }



    }


}