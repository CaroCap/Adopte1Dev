using Adopte1Dev.BLL.Entities;
using Adopte1Dev.Common;
using Adpote1Dev.Handlers;
using Adpote1Dev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
            IEnumerable<DeveloperListItem> model = _developeurService.Get().Select(d => d.ToListItem());
            //model.Categories = _categoriesService.GetByCinemaId(id).Select(d => d.ToDetails());
            model = model.Select(m => { m.CategPrincipale =(m.DevCategPrincipal is null)? null : _categoriesService.Get((int)m.DevCategPrincipal).ToDetails(); return m; });
            return View(model);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        public IActionResult Details(int id)
        {
            DeveloperDetails model = _developeurService.Get(id).ToDetails();
            if (!(model.DevCategPrincipal is null))
            {
                model.CategPrincipale = _categoriesService.Get((int)model.DevCategPrincipal).ToDetails();
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

        // GET: DeveloperController/Create
        public IActionResult Create()
        {
            DeveloperCreateForm model = new DeveloperCreateForm();
            // On va utiliser linQ pour aller récupérer la catégorie de notre student = .Select
            // On va utiliser LinQ pour n'avoir qu'une seule fois chaque élément = .Distinct
            // On peut ajouter ToList() ou ToArray() si besoin mais nous on veut IEnumerable donc pas besoin
            model.CategoriesList = _categoriesService.Get().Select(s => s.ToDetails());
            model.DevBirthDate = DateTime.Now;
            //IEnumerable<CategoriesBLL> languages = _categoriesService.Get(); // STEF
            //model.CategoriesLabels = languages.ToString(); // STEF
            return View(model);
        }

        // POST: DeveloperController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(DeveloperCreateForm collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                DeveloperBLL result = new DeveloperBLL(0,
                    collection.DevName,
                    collection.DevFirstName,
                    collection.DevBirthDate,
                    collection.DevPicture,
                    collection.DevHourCost,
                    collection.DevDayCost,
                    collection.DevMonthCost,
                    collection.DevMail,
                    collection.DevCategPrincipal
                );
                result.idDev = this._developeurService.Insert(result);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                collection.CategoriesList = _categoriesService.Get().Select(s => s.ToDetails());
                return View(collection);
            }
        }

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
