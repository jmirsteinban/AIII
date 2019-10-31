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

        private SalesViewModel Convertir(sale FacturaM, IEnumerable<sp_Get_factura_detalle_Result> FacturaD)
        {
            client Cliente;
            user Empleado;
            List<Producto> Productos= new List<Producto>();

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
                foreach (var item in FacturaD)
                {
                    Producto detalles = new Producto
                    {
                        productName= unidad.genericDAL.Get((int)item.productID).nombre_producto,
                        cedCliente= Cliente.cedula_cliente,
                        cedUsuario=Empleado.cedula_user,
                        cantProd=item.cantidad,
                        estado=FacturaM.estado_factura,
                        precio_factura_d=item.precio_factura_d
                    };

                    Productos.Add(detalles);
                }                
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
                productosDetalle=Productos
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

        private sale ConvertirMaestroCreate(string cedula_cliente,string cedula_user, string estado)
        {
            sp_Get_Client_X_Cedula_Result Cliente;
            sp_Get_User_X_Cedula_Result Empleado;

            using (WorkUnit<client> unidad = new WorkUnit<client>(new BDContext()))
            {
                Cliente = unidad.clientsDAL.Client(cedula_cliente);
            }

            using (WorkUnit<user> unidad = new WorkUnit<user>(new BDContext()))
            {
                Empleado = unidad.usersDAL.User(cedula_user);
            }            

            sale Factura = new sale
            {                
                clientID=Cliente.clientID,
                userID=Empleado.userID,
                fecha_compra=DateTime.Now,
                estado_factura=estado         
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
                estado_factura=facturas.estado_factura,
            };

            return Factura;
        }

        private sales_x_products ConvertirDetalle(sale factura, string nombre_producto, int cantidad)
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
                productID=Producto.productID,
                cantidad=cantidad
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

                    productName = item.nombre_producto,
                    precio_factura_d=item.precio_venta ,
                    cantProd=item.cantidad
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
                IEnumerable<sp_Get_factura_detalle_Result> FacDet;

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
            ViewBag.CedulaUser = Session["cedula"];

            return View();
        }

        // POST: Facturas/Create
        [HttpPost]
        public ActionResult Create(SalesViewModel salesViewModel, Producto[] order)
        {
            try
            {
                string cedula_cliente= order[0].cedCliente, cedula_user= order[0].cedUsuario,
                       estado= order[0].estado;                

                sale Factura;
                sales_x_products FactDetalle;

                using (WorkUnit<sale> unit = new WorkUnit<sale>(new BDContext()))
                {
                    Factura = ConvertirMaestroCreate(cedula_cliente, cedula_user, estado);
                    decimal totalFactura = 0;
                    Factura.monto_total = totalFactura;

                    unit.genericDAL.Add(Factura);
                    unit.Complete();

                    foreach (var item in order)
                    {
                        using (WorkUnit<sales_x_products> unit2 = new WorkUnit<sales_x_products>(new BDContext()))
                        {
                            FactDetalle = ConvertirDetalle(Factura, item.productName,Convert.ToInt32(item.cantProd));
                            totalFactura = totalFactura + (FactDetalle.precio_factura_d*FactDetalle.cantidad);
                            unit2.genericDAL.Add(FactDetalle);
                            unit2.Complete();
                        }
                    }

                    Factura.monto_total = totalFactura;
                    unit.genericDAL.Update(Factura);
                    unit.Complete();
                }

                client Cliente;

                using (WorkUnit<client> unit = new WorkUnit<client>(new BDContext()))
                {
                    Cliente = unit.genericDAL.Get(Factura.clientID);
 
                }

                return Json(Cliente.primer_nombre_cliente + " " +
                        Cliente.primer_apellido_cliente + " " + Cliente.segundo_apellido_cliente,
                        JsonRequestBehavior.AllowGet);
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
                IEnumerable<sp_Get_factura_detalle_Result> FacDet;

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

                using (WorkUnit<sale> unit = new WorkUnit<sale>(new BDContext()))
                {
                    sale Factura = new sale
                    {
                        compraID=salesViewModel.compraID,
                        clientID=salesViewModel.clientID,
                        userID=salesViewModel.userID,
                        fecha_compra=salesViewModel.fecha_compra,
                        monto_total=salesViewModel.monto_total,
                        estado_factura=salesViewModel.estado_factura
                    };

                    unit.genericDAL.Delete(Factura);
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

