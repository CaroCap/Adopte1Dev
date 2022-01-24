using Adopte1Dev.BLL.Entities;
using Adopte1Dev.Common;
using Adpote1Dev.Handlers;
using Adpote1Dev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Adpote1Dev.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository<DeveloperBLL> _developeurService;
        private readonly ICategoriesRepository<CategoriesBLL> _categoriesService;

        public DeveloperController(IDeveloperRepository<DeveloperBLL> developeurService, ICategoriesRepository<CategoriesBLL> categoriesService)
        {
            _developeurService = developeurService;
            _categoriesService = categoriesService;
        }

        //Constructeur

        public IActionResult Index()
        {
            IEnumerable<DeveloperListItem> model = _developeurService.Get().Select(d => d.ToListItem());
            //model.Categories = _categoriesService.GetByCinemaId(id).Select(d => d.ToDetails());
            return View(model);
        }

        public IActionResult Details(int id)
        {
            DeveloperDetails model = _developeurService.Get(id).ToDetails();
            if (!(model.CategPrincipale is null))
            {
                int catID = model.DevCategPrincipal ?? 0;
                model.CategPrincipale = _categoriesService.Get(catID).ToDetails();
            } 
            //model.Diffusions = _diffusionService.GetByCinemaId(id).Select(d => d.ToDetails());
            return View(model);
        }
        
        //// GET: DeveloperController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: DeveloperController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DeveloperController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DeveloperController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DeveloperController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DeveloperController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DeveloperController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DeveloperController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
