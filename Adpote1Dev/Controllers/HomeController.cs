using Adopte1Dev.BLL.Entities;
using Adopte1Dev.Common;
using Adopte1Dev.DAL.Entities;
using Adpote1Dev.Handlers;
using Adpote1Dev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Adpote1Dev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientRepository<ClientBLL> _clientService;
        //private readonly SessionManager session;


        //public HomeController(ILogger<HomeController> logger, SessionManager session)
        //{
        //    _logger = logger;
        //    this.session = session;
        //}
        public HomeController(ILogger<HomeController> logger, IClientRepository<ClientBLL> clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Developer"); // On redirige pour que quand on va sur le home on soit direct rediriger vers Cinema/Index
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //LOGIN & SESSION

        public IActionResult Login()
        {
            //if (session.IsConnected) return RedirectToAction("Index", "Home");
            return View();
        }

        ///// <summary>
        ///// Action récupérant le formulaire dans un model LoginForm, que j'ai créé moi-même, permet de travailler les donnée d'un formulaire.
        ///// ATTENTION : Signature doit être différente de l'affichage du formulaire, et être d'un HttpVerb différent, si l'affichage est en GET, la récupération est en POST (vérifier que la balise form contienne une méthode POST) : [HttpPost]
        ///// </summary>
        ///// <param name="formCollection"></param>
        ///// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            //ValidateLoginForm(form, ModelState);
            if (!ModelState.IsValid) return View();
            if (_clientService.checkPassword(form.CliLogin, form.CliPassword) == -1) return View();
            //session.SetUser(form);
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult LogOut()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login");
        //}

        public IActionResult LoginCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginCreate(LoginCreate newClient)
        {
            //ValidateLoginForm(form, ModelState);
            if (!ModelState.IsValid) return View();
            ClientBLL result = new ClientBLL(
                0,
                newClient.CliName,
                newClient.CliFirstName,
                newClient.CliMail,
                newClient.CliCompany,
                newClient.CliLogin,
                newClient.CliPassword
                );
            result.idClient = this._clientService.Insert(result);
            //session.SetUser(form);
            return RedirectToAction("Index", "Home");
        }
    }
}
