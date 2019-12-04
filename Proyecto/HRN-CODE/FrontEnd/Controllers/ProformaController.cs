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
using System.Configuration;

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

            List<client> listaClientes;
            using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
            {
                listaClientes = workUnit.genericDAL.GetAll().Where(x => x.estado_cliente == "Activo").ToList();
            }

            List<Estado> estados = new List<Estado>();
            estados.Insert(0, new Estado { nombreEstado = "Completado" });
            estados.Insert(1, new Estado { nombreEstado = "Procesando" });

            ViewBag.Productos = products;
            ViewBag.Clientes = listaClientes;
            ViewBag.Estados = estados;
        }


        private string enviar_correo(Producto[] order)
        {

            List<client> listaClientes;
            using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
            {
                listaClientes = workUnit.genericDAL.GetAll().Where(x => x.cedula_cliente == order[0].cedCliente).ToList();
            }
            if(listaClientes.Count != 0)
            {
                try
                {
                    /*Inicio de appsettings*/
                    string rutaPDF = System.Configuration.ConfigurationManager.AppSettings["RutaGeneradorPDF"].ToString();
                    string rutaHTML = System.Configuration.ConfigurationManager.AppSettings["RutaPlantillaHTML"].ToString();
                    string plantilla_html =  rutaHTML + "proforma.html";
                    string plantilla_comodines = System.IO.File.ReadAllText(plantilla_html);
                    string correo_notificacion = System.Configuration.ConfigurationManager.AppSettings["Correo_Notificacion"].ToString();
                    string pass_correo = System.Configuration.ConfigurationManager.AppSettings["Pass_Notificacion"].ToString();
                    /*cierre de appsetings*/

                    Random rnd = new Random();
                    int numero = rnd.Next(1, 1000);
                    var html_tabla = "";
                    decimal total_factura = 0;
                    decimal total_linea = 0;
                    foreach (var product in order)
                    {
                        total_linea = product.precio_factura_d; 
                        html_tabla += "<tr>";
                        html_tabla += "<td>" + product.productName+ "</td>";
                        html_tabla += "<td>" + product.cantProd + "</td>";
                        html_tabla += "<td>" + String.Format("{0:n}", total_linea)  + "</td>";
                        html_tabla += "</tr>";
                        total_factura = total_factura + product.precio_factura_d;
                    }
                    plantilla_comodines = plantilla_comodines.Replace("@tabla", html_tabla);
                    plantilla_comodines = plantilla_comodines.Replace("@Numero_Proforma", "PROFORMA-" + numero.ToString());
                    plantilla_comodines = plantilla_comodines.Replace("@Cliente_proforma", order[0].cedCliente);
                    plantilla_comodines = plantilla_comodines.Replace("@Fecha_proforma", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    plantilla_comodines = plantilla_comodines.Replace("@Total_Proforma", String.Format("{0:n}",total_factura));
                    IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
                    Renderer.PrintOptions.CreatePdfFormsFromHtml = true;
                    string html_cuerpo = "";
                    html_cuerpo = "<html>";
                    html_cuerpo += "<body>";
                    html_cuerpo += "<p>Estimado (a) cliente: " + listaClientes[0].primer_nombre_cliente + " " + listaClientes[0].primer_apellido_cliente + "</p><br>";
                    html_cuerpo += "<p>Adjunto encontrará la factura proforma solicitada.</p><br>";
                    html_cuerpo += "<p>Saludos,</p>";
                    html_cuerpo += "</body>";
                    html_cuerpo += "</html>";
                    Renderer.RenderHtmlAsPdf(plantilla_comodines).SaveAs(rutaPDF + "proforma" + numero.ToString() + ".pdf");
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                    mail.From = new MailAddress(correo_notificacion);
                    mail.To.Add(listaClientes[0].correo_electronico_cliente);
                    //mail.To.Add("dpadillam1@hotmail.com");
                    mail.CC.Add("dpadillam1@hotmail.com");
                    mail.Subject = "Nueva Proforma - " + numero.ToString();
                    mail.IsBodyHtml = true;
                    mail.Body = html_cuerpo;
                    mail.Attachments.Add(new Attachment(rutaPDF+  "proforma" + numero.ToString() + ".pdf"));
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(correo_notificacion, pass_correo);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
            else
            {
                return "2";
            }
            
        }


        [HttpPost]
        public ActionResult Create(SalesViewModel salesViewModel, Producto[] order)
        {
            try
            {
                string respuesta = enviar_correo(order);
                return Json(respuesta,
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