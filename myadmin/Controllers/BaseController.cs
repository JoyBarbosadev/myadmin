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
                ViewBag.corpo = message;
                ViewBag.tipo = tipo;
            }
            else
            {
                TempData["Ativo"] = true;
                TempData["Titulo"] = title;
                TempData["Corpo"] = message;
                TempData["Tipo"] = tipo;
            }
        }
    }
}