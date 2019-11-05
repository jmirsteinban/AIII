using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IronPdf;
using System.Net.Mail;

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


        private void enviar_correo(Producto[] order)
        {
            string plantilla_html = @"C:\Users\dpadilla\Downloads\pdf\proforma.html";
            string plantilla_comodines = System.IO.File.ReadAllText(plantilla_html);
            Random rnd = new Random();
            int numero = rnd.Next(1, 1000);

            var html_tabla = "";
            foreach (var product in order)
            {
                html_tabla += "<tr>";
                html_tabla += "<td>" + product.cantProd + "</td>";
                html_tabla += "<td>" +product.productName +"</td>";
                html_tabla += "<td>" + "1000" + "</td>";
                html_tabla += "<td>" + product.cantProd  * 1000 + "</td>";
                html_tabla += "</tr>";

            }
            plantilla_comodines = plantilla_comodines.Replace("@tabla", html_tabla);
            plantilla_comodines = plantilla_comodines.Replace("@proforma", "PROFORMA-"+numero.ToString());
            plantilla_comodines = plantilla_comodines.Replace("@Cliente", order[0].cedCliente);
            plantilla_comodines = plantilla_comodines.Replace("@usuario", order[0].cedUsuario);
            IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            Renderer.PrintOptions.CreatePdfFormsFromHtml = true;
            string html_cuerpo = "";
            html_cuerpo = "<html>";
            html_cuerpo += "<body>";
            html_cuerpo += "<p>Estimado cliente:</p><br>";
            html_cuerpo += "<p>Adjunto encontrará la factura proforma solicitada.</p><br>";
            html_cuerpo += "<p>Saludos,</p>";
            html_cuerpo += "</body>";
            html_cuerpo += "</html>";
            Renderer.RenderHtmlAsPdf(plantilla_comodines).SaveAs(@"C:\Users\dpadilla\Downloads\pdf\proforma"+numero.ToString()+".pdf");
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            mail.From = new MailAddress("diego.padilla.miranda@hotmail.com");
            mail.To.Add("dpadillam1@hotmail.com");
            mail.Subject = "Nueva Proforma - " + numero.ToString();
            mail.IsBodyHtml = true;
            mail.Body = html_cuerpo;
            mail.Attachments.Add(new Attachment(@"C:\Users\dpadilla\Downloads\pdf\proforma" + numero.ToString() + ".pdf"));
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("diego.padilla.miranda@hotmail.com", "0ym754rbn58");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }


        [HttpPost]
        public ActionResult Create(SalesViewModel salesViewModel, Producto[] order)
        {
            try
            {
                enviar_correo(order);
                /*string cedula_cliente = order[0].cedCliente, cedula_user = order[0].cedUsuario,
                       estado = order[0].estado;

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
                            FactDetalle = ConvertirDetalle(Factura, item.productName, Convert.ToInt32(item.cantProd));
                            totalFactura = totalFactura + (FactDetalle.precio_factura_d * FactDetalle.cantidad);
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
                        JsonRequestBehavior.AllowGet);*/
                return Json("1",
                JsonRequestBehavior.AllowGet);
            }
            catch (Exception msj)
            {
                string proveedor = "Crear Compra";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar un cliente existente y de ingresar los datos en el formato correcto!";
                string exception = msj.Message;
                string redirection = "Create/" + salesViewModel.compraID;
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
        private sales_x_products ConvertirDetalle(sale factura, string nombre_producto, int cantidad)
        {
            sp_Get_producto_x_nombre_Result Producto;

            using (WorkUnit<product> unidad = new WorkUnit<product>(new BDContext()))
            {
                Producto = unidad.salesDAL.GetProducto(nombre_producto);
            }

            sales_x_products FacturaD = new sales_x_products
            {
                compraID = factura.compraID,
                precio_factura_d = Producto.precio_venta,
                productID = Producto.productID,
                cantidad = cantidad
            };

            return FacturaD;
        }
        private sale ConvertirMaestroCreate(string cedula_cliente, string cedula_user, string estado)
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
                clientID = Cliente.clientID,
                userID = Empleado.userID,
                fecha_compra = DateTime.Now,
                estado_factura = estado
            };

            return Factura;
        }
    }
}