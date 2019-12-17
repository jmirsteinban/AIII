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
    [Authorize(Roles = "Administrador,Consulta")]

    public class ProductsController : Controller
    {
        public ProductsViewModel Convertir(product Product)
        {
            ProductsViewModel productsViewModel = new ProductsViewModel
            {
                productID=Product.productID,
                codigo_producto= Product.codigo_producto,
                nombre_producto= Product.nombre_producto,
                descripcion=Product.descripcion,
                cantidad=Product.cantidad,
                precio_manufactura=(decimal) Product.precio_manufactura,
                precio_venta=Product.precio_venta,
                estado_producto=Product.estado_producto,
                porcentaje_ganancia=Product.porcentaje_ganancia,
                porcentaje_descuento=(decimal)Product.porcentaje_descuento
            };
            return productsViewModel;
        }

        public product Convertir(ProductsViewModel productsViewModel)
        {
            product Producto = new product
            {
                productID=productsViewModel.productID,
                codigo_producto=productsViewModel.codigo_producto,
                nombre_producto=productsViewModel.nombre_producto,
                descripcion=productsViewModel.descripcion,
                cantidad=productsViewModel.cantidad,
                precio_manufactura=productsViewModel.precio_manufactura,
                precio_venta=productsViewModel.precio_venta,
                estado_producto=productsViewModel.estado_producto,
                porcentaje_ganancia=productsViewModel.porcentaje_ganancia,
                porcentaje_descuento=productsViewModel.porcentaje_descuento                
            };
            return Producto;
        }

        private void LlenarEstados()
        {
            List<Estado> estados = new List<Estado>
            {
                new Estado{nombreEstado="Disponible"},
                new Estado{nombreEstado="Agotado"},
                new Estado{nombreEstado="Descontinuado"}
            };

            ViewBag.Estados = estados;

        }

        private void LlenarEstados(string estado)
        {
            List<Estado> estados = new List<Estado>
            {
                new Estado{nombreEstado="Disponible"},
                new Estado{nombreEstado="Agotado"},
                new Estado{nombreEstado="Descontinuado"}
            };
            estados.Insert(0, new Estado { nombreEstado=estado});

            ViewBag.Estados = estados;

        }

        // GET: Products
        public ActionResult Index()
        {
            List<product> lista;
            using (WorkUnit<product> workUnit= new WorkUnit<product>(new BDContext()))
            {
                lista=workUnit.genericDAL.GetAll().ToList();
            }

            List<ProductsViewModel> listaModel = new List<ProductsViewModel>();
            foreach (var item in lista)
            {
                listaModel.Add(Convertir(item));
            }

            return View(listaModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                product Product;

                using (WorkUnit<product> workUnit = new WorkUnit<product>(new BDContext()))
                {
                    Product = workUnit.genericDAL.Get(id);
                }

                return View(Convertir(Product));
            }
            catch (Exception msj)
            {
                string proveedor = "Detalles Producto";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "seleccionar un producto existente!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Products";

                return RedirectToAction("Error", new RouteValueDictionary
                    (new
                    {
                        Controller = "Error",
                        Action = "Error",
                        proveedor = proveedor,
                        mensaje = mensaje,
                        exception = exception,
                        redirection = redirection,
                        controller2 = controller2
                    }));
            }            
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            LlenarEstados();

            return View();
        }


        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(ProductsViewModel products)
        {
            try
            {
                bool seguir = true;

                if (products.precio_manufactura==0 || products.precio_venta==0)
                {
                    throw new Exception();
                }

                using (WorkUnit<product> workUnit = new WorkUnit<product>(new BDContext()))
                {
                    workUnit.genericDAL.Add(Convertir(products));
                    seguir=workUnit.Complete();
                }

                if (!seguir)
                {
                    throw new Exception();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Crear Producto";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "ingresando la información del producto en su debido formato y que no hayan duplicados (Código Producto)!";
                string exception = msj.Message;
                string redirection = "Create";
                string controller2 = "Products";

                return RedirectToAction("Error", new RouteValueDictionary
                    (new
                    {
                        Controller = "Error",
                        Action = "Error",
                        proveedor = proveedor,
                        mensaje = mensaje,
                        exception = exception,
                        redirection = redirection,
                        controller2 = controller2
                    }));
            }
        }

        [Authorize(Roles = "Administrador")]
        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                product Product;

                using (WorkUnit<product> workUnit = new WorkUnit<product>(new BDContext()))
                {
                    Product = workUnit.genericDAL.Get(id);
                }

                LlenarEstados(Product.estado_producto);

                return View(Convertir(Product));
            }
            catch (Exception msj)
            {
                string proveedor = "Editar Producto";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar un producto existente y de ingresar los datos en el formato correcto!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Products";

                return RedirectToAction("Error", new RouteValueDictionary
                    (new
                    {
                        Controller = "Error",
                        Action = "Error",
                        proveedor = proveedor,
                        mensaje = mensaje,
                        exception = exception,
                        redirection = redirection,
                        controller2 = controller2
                    }));
            }            
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductsViewModel productsViewModel)
        {
            try
            {
                bool seguir = true;
                
                using (WorkUnit<product> workUnit= new WorkUnit<product>(new BDContext()))
                {
                    workUnit.genericDAL.Update(Convertir(productsViewModel));
                    seguir=workUnit.Complete();
                }

                if (!seguir)
                {
                    throw new Exception();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Editar Producto";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar un producto existente y de ingresar los datos en el formato correcto y que no hayan duplicados (Código Producto)!";
                string exception = msj.Message;
                string redirection = "Edit/" + productsViewModel.productID;
                string controller2 = "Products";

                return RedirectToAction("Error", new RouteValueDictionary
                    (new
                    {
                        Controller = "Error",
                        Action = "Error",
                        proveedor = proveedor,
                        mensaje = mensaje,
                        exception = exception,
                        redirection = redirection,
                        controller2 = controller2
                    }));
            }
        }

        [Authorize(Roles = "Administrador")]
        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                product Producto;

                using (WorkUnit<product> workUnit = new WorkUnit<product>(new BDContext()))
                {
                    Producto = workUnit.genericDAL.Get(id);
                }

                return View(Convertir(Producto));
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Producto";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar un producto existente y de ingresar los datos en el formato correcto!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Products";

                return RedirectToAction("Error", new RouteValueDictionary
                    (new
                    {
                        Controller = "Error",
                        Action = "Error",
                        proveedor = proveedor,
                        mensaje = mensaje,
                        exception = exception,
                        redirection = redirection,
                        controller2 = controller2
                    }));
            }            
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductsViewModel productsViewModel)
        {
            try
            {
                using (WorkUnit<product> workUnit = new WorkUnit<product>(new BDContext()))
                {
                    workUnit.genericDAL.Delete(Convertir(productsViewModel));
                    workUnit.Complete();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Producto";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar un producto existente y de tener los permisos para realizar el proceso!";
                string exception = msj.Message;
                string redirection = "Delete/"+productsViewModel.productID;
                string controller2 = "Products";

                return RedirectToAction("Error", new RouteValueDictionary
                    (new
                    {
                        Controller = "Error",
                        Action = "Error",
                        proveedor = proveedor,
                        mensaje = mensaje,
                        exception = exception,
                        redirection = redirection,
                        controller2 = controller2
                    }));
            }
        }
    }
}
