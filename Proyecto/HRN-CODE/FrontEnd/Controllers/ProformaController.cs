using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace FrontEnd.Controllers
{
    public class ProformaController : Controller
    {
        // GET: Proforma
        public ActionResult Create()
        {
            LlenarLista();
            ViewBag.CedulaUser = Session["cedula"];

            return View();
        }

        private void LlenarLista()
        {
            List<product> Productos;

            using (WorkUnit<product> unidad = new WorkUnit<product>(new BDContext()))
            {
                Productos = unidad.genericDAL.GetAll().ToList();
            }

            List<Producto> products = new List<Producto>();

            foreach (var item in Productos)
            {
                Producto producto = new Producto
                {

                    productName = item.nombre_producto,
                    precio_factura_d = item.precio_venta,
                    cantProd = item.cantidad
                };

                products.Add(producto);
            }

            List<Estado> estados = new List<Estado>();
            estados.Insert(0, new Estado { nombreEstado = "Completado" });
            estados.Insert(1, new Estado { nombreEstado = "Procesando" });

            ViewBag.Productos = products;
            ViewBag.Estados = estados;
        }
    }
}