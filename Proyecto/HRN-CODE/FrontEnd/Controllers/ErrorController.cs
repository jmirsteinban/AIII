using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class ErrorController : Controller
    {
        // Para cuando faltan permisos para acceder al sistema
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Error
        public ActionResult Error(string proveedor,string mensaje,
            string exception,string redirection, string controller2)
        {
            ViewBag.Proveedor = proveedor;
            ViewBag.Mensaje = mensaje;
            ViewBag.Exception = exception;
            ViewBag.Redirection = redirection;
            ViewBag.Controller = controller2;

            return View();
        }

        // GET: Error/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Error/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Error/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }        
    }
}
