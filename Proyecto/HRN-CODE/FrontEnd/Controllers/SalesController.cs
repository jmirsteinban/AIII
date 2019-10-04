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
    public class SalesController : Controller
    {
        [Authorize(Roles = "Administrador,Consulta")]

        private SalesViewModel Convertir(sale FacturaM, sp_Get_factura_detalle_Result FacturaD)
        {
            client Cliente;
            user Empleado;
            product Producto;

            using (WorkUnit<client> unidad = new WorkUnit<client>(new BDContext()))
            {
                Cliente = unidad.genericDAL.Get((int)FacturaM.clientID);                
            }

            using (WorkUnit<user> unidad = new WorkUnit<user>(new BDContext()))
            {
                Empleado = unidad.genericDAL.Get((int)FacturaM.userID);                
            }

            using (WorkUnit<product> unidad = new WorkUnit<product>(new BDContext()))
            {
                Producto = unidad.genericDAL.Get((int)FacturaD.productID);
            }

            SalesViewModel Facturas = new SalesViewModel
            {
                compraID=FacturaM.compraID,
                clientID=FacturaM.clientID,
                cedula_cliente=Cliente.cedula_cliente,
                userID=FacturaM.userID,
                cedula_user=Empleado.cedula_user,
                fecha_compra=(DateTime) FacturaM.fecha_compra,
                monto_total=FacturaM.monto_total,
                estado_factura=FacturaM.estado_factura,
                compraID_detalle=FacturaD.compraID_detalle,
                compraID_Detail=FacturaM.compraID,
                productID=FacturaD.productID,
                nombre_producto=Producto.nombre_producto,
                precio_factura_d=FacturaD.precio_factura_d
            };

            return Facturas;
        }

        private sale ConvertirMaestro(SalesViewModel facturas)
        {
            sp_Get_Client_X_Cedula_Result Cliente;
            sp_Get_User_X_Cedula_Result Empleado;
            sp_Get_producto_x_nombre_Result Producto;

            using (WorkUnit<client> unidad = new WorkUnit<client>(new BDContext()))
            {
                Cliente = unidad.clientsDAL.Client(facturas.cedula_cliente);
            }

            using (WorkUnit<user> unidad = new WorkUnit<user>(new BDContext()))
            {
                Empleado = unidad.usersDAL.User(facturas.cedula_user);
            }            

            using (WorkUnit<product> unidad = new WorkUnit<product>(new BDContext()))
            {
                Producto = unidad.salesDAL.GetProducto(facturas.nombre_producto);
            }

            sale Factura = new sale
            {                
                clientID=Cliente.clientID,
                userID=Empleado.userID,
                fecha_compra=DateTime.Now,
                estado_factura=facturas.estado_factura,
                monto_total=Producto.precio_venta                
            };

            return Factura;
        }

        private SalesViewModel ConvertirMaestro(sale facturas)
        {
            client Cliente;

            using (WorkUnit<client> unidad = new WorkUnit<client>(new BDContext()))
            {
                Cliente = unidad.genericDAL.Get((int)facturas.clientID);
            }

            user empleado;

            using (WorkUnit<user> unidad = new WorkUnit<user>(new BDContext()))
            {
                empleado = unidad.genericDAL.Get((int)facturas.userID);
            }

            product Producto;

            using (WorkUnit<product> unidad = new WorkUnit<product>(new BDContext()))
            {
                Producto = unidad.genericDAL.Get((int)facturas.compraID);
            }

            SalesViewModel Factura = new SalesViewModel
            {
                compraID=facturas.compraID,
                clientID=facturas.clientID,
                cedula_cliente=Cliente.cedula_cliente,
                userID=facturas.userID,
                cedula_user=empleado.cedula_user,
                fecha_compra=(DateTime) facturas.fecha_compra,
                monto_total=facturas.monto_total,
                estado_factura=facturas.estado_factura
            };

            return Factura;
        }

        private sales_x_products ConvertirDetalle(sale factura, string nombre_producto)
        {
            sp_Get_producto_x_nombre_Result Producto;

            using (WorkUnit<product> unidad = new WorkUnit<product>(new BDContext()))
            {
                Producto = unidad.salesDAL.GetProducto(nombre_producto);
            }

            sales_x_products FacturaD = new sales_x_products
            {                
                compraID= factura.compraID,
                precio_factura_d=Producto.precio_venta,
                productID=Producto.productID
            };

            return FacturaD;
        }

        private void LlenarLista()
        {

            List<product> Productos;

            using (WorkUnit<product> unidad = new WorkUnit<product>(new BDContext()))
            {
                Productos=unidad.genericDAL.GetAll().ToList();
            }

            List<Producto> products = new List<Producto>();

            foreach (var item in Productos)
            {
                Producto producto = new Producto
                {
                    nombreProducto=item.nombre_producto
                };

                products.Add(producto);
            }

            List<Estado> estados = new List<Estado>();
            estados.Insert(0, new Estado { nombreEstado="Completado"});
            estados.Insert(1, new Estado { nombreEstado="Procesando"});           

            ViewBag.Productos = products;
            ViewBag.Estados = estados;
        }
        

        // GET: Facturas
        public ActionResult Index()
        {
            List<sale> ListaMaestro;

            using (WorkUnit<sale> unidad = new WorkUnit<sale>(new BDContext()))
            {
                ListaMaestro = unidad.genericDAL.GetAll().ToList();
            }

            List<SalesViewModel> facturas = new List<SalesViewModel>();

            foreach (var item in ListaMaestro)
            {
                facturas.Add(ConvertirMaestro(item));
            }

            return View(facturas);
        }
        

        // GET: Facturas/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                sale FacMaes;
                sp_Get_factura_detalle_Result FacDet;

                using (WorkUnit<sale> unit = new WorkUnit<sale>(new BDContext()))
                {
                    FacMaes = unit.genericDAL.Get(id);
                }

                using (WorkUnit<sales_x_products> unit = new WorkUnit<sales_x_products>(new BDContext()))
                {
                    FacDet = unit.salesDAL.GetFacturaDetalle(id);
                }

                return View(Convertir(FacMaes, FacDet));
            }
            catch (Exception msj)
            {
                string proveedor = "Detalles Compra";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "seleccionar una compra existente!";
                string exception = msj.Message;
                string redirection = "Create";
                string controller2 = "Sales";

                return RedirectToAction("Error", new RouteValueDictionary(
                    new {
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

        // GET: Facturas/Create
        public ActionResult Create()
        {
            LlenarLista();

            return View();
        }

        // POST: Facturas/Create
        [HttpPost]
        public ActionResult Create(SalesViewModel salesViewModel)
        {
            try
            {
                sale Factura;

                using (WorkUnit<sale> unit = new WorkUnit<sale>(new BDContext()))
                {
                    Factura = ConvertirMaestro(salesViewModel);
                    unit.genericDAL.Add(Factura);
                    unit.Complete();
                }                
                
                using (WorkUnit<sales_x_products> unit = new WorkUnit<sales_x_products>(new BDContext()))
                {
                    unit.genericDAL.Add(ConvertirDetalle(Factura,salesViewModel.nombre_producto));
                    unit.Complete();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Crear Compra";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar un cliente existente y de ingresar los datos en el formato correcto!";
                string exception = msj.Message;
                string redirection = "Edit/" + salesViewModel.compraID;
                string controller2 = "Sales";

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

        /*
        // GET: Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Facturas/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                sale FacMaes;
                sp_Get_factura_detalle_Result FacDet;

                using (WorkUnit<sale> unit = new WorkUnit<sale>(new BDContext()))
                {
                    FacMaes = unit.genericDAL.Get(id);
                }

                using (WorkUnit<sales_x_products> unit = new WorkUnit<sales_x_products>(new BDContext()))
                {
                    FacDet = unit.salesDAL.GetFacturaDetalle(id);
                }

                return View(Convertir(FacMaes, FacDet));
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Compra";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar una compra existente y de tener los permisos para realizar el proceso!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Sales";

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

        // POST: Facturas/Delete/5
        [HttpPost]
        public ActionResult Delete(SalesViewModel salesViewModel)
        {
            try
            {
                sale Factura;

                using (WorkUnit<sale> unit = new WorkUnit<sale>(new BDContext()))
                {
                    Factura = ConvertirMaestro(salesViewModel);
                    unit.genericDAL.Delete(Factura);
                    unit.Complete();
                }

                using (WorkUnit<sales_x_products> unit = new WorkUnit<sales_x_products>(new BDContext()))
                {
                    unit.genericDAL.Delete(ConvertirDetalle(Factura,salesViewModel.nombre_producto));
                    unit.Complete();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Compra";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "borrando la información de una compra que no tiene dependencias!";
                string exception = msj.Message;
                string redirection = "Delete/" + salesViewModel.compraID;
                string controller2 = "Sales";

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

        public ActionResult CerrarSesion()
        {
            return RedirectToAction("LogOut","Login");
        }
    }
}

