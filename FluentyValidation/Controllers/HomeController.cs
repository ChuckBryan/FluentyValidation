﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using FluentyValidation.Models;
using MediatR;
using WebGrease.Css.Extensions;

namespace FluentyValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(Customer model)
        {

            try
            {
                await _mediator.SendAsync(model);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
/*                ex.Errors.ForEach(e=>
                {
                    ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
                });*/
                return View(model);
            }
            catch (Exception)
            {
                
                throw;
            }

            
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult IsASwampy(string email)
        {
            return Json(email.ToLower().StartsWith("swampy"), JsonRequestBehavior.AllowGet);
        }
    }
}