using myadmin.Models;
using myadmin.Negocio.Entidade;
using myadmin.Negocio.Processo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myadmin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Validar(LoginModels model)
        {
            BPLogin bplogin = new BPLogin();

            if (!bplogin.Validar(model.usuario, model.senha))
            {
                AddMessage("Autenticação", "Usuário e/ou Senha não foram identificados.", "erro", true);
                return RedirectToAction("Index");
            }
            String token = bplogin.RecuperarToken(model.usuario, model.senha);

            if (!bplogin.UsuarioAtivo(token))
            {
                AddMessage("Autenticação", "Sua conta está bloqueada. Entre em contato com o Administrador do Sistema.", "error", true);
                return RedirectToAction("Index");
            }
            else
            {
                Session["TOKEN"] = token;
                Session["VISAO"] = false;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioModels model)
        {
            BEUsuario usuario = new BEUsuario()
            {
                nome = model.nome,
                sobrenome = model.sobrenome,
                email = model.email,
                senha = model.senha,
                ativo = "S"
            };

            BPUsuario bp = new BPUsuario();
            if (!bp.ValidaUnidade(usuario))
            {
                this.AddMessage("Cadastro", "Usuario já cadastrada em nossa base dados", "warning");
                return View(model);
            }
            try
            {
                    new BPUsuario().InserirOuAtualizar(usuario);
                    this.AddMessage("Cadastro", "Cadastro realizado com sucesso, em breve retornaremos o contato.", "success", true);
                    return RedirectToAction("Index");               

            }
            catch (Exception e)
            {
                this.AddMessage("Cadastro", "Não foi possível reliazar o cadastro, tente novamente ou entre em contato com o administrador do sistema.", "warning");
                return View(model);
            }
        }
    }
}