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
    public class ClientsController : Controller
    {
        [Authorize(Roles = "Administrador,Consulta")]

        public ClientsViewModel Convertir(client Client,sp_phones_clients_Result telefono,sp_directions_clients_Result direccion)
        {
            ClientsViewModel clientsViewModel = new ClientsViewModel
            {
                clientID=Client.clientID,
                cedula_cliente=Client.cedula_cliente,
                primer_nombre_cliente=Client.primer_nombre_cliente,
                segundo_nombre_cliente=Client.segundo_nombre_cliente,
                primer_apellido_cliente=Client.primer_apellido_cliente,
                segundo_apellido_cliente=Client.segundo_apellido_cliente,
                correo_electronico_cliente=Client.correo_electronico_cliente,
                estado_cliente=Client.estado_cliente,
                direccionID=direccion.direccionID,
                direccion= direccion.direccion,
                telefonoID=telefono.telefonoID,
                telefono=telefono.telefono
            };
            return clientsViewModel;
        }

        public ClientsViewModel Convertir(client Client)
        {
            ClientsViewModel clientsViewModel = new ClientsViewModel
            {
                clientID=Client.clientID,
                cedula_cliente=Client.cedula_cliente,
                primer_nombre_cliente=Client.primer_nombre_cliente,
                segundo_nombre_cliente=Client.segundo_nombre_cliente,
                primer_apellido_cliente=Client.primer_apellido_cliente,
                segundo_apellido_cliente=Client.segundo_apellido_cliente,
                correo_electronico_cliente=Client.correo_electronico_cliente,
                estado_cliente=Client.estado_cliente
            };
            return clientsViewModel;
        }

        public client Convertir(ClientsViewModel clientsViewModel)
        {
            client Cliente = new client
            {
                clientID = clientsViewModel.clientID,
                cedula_cliente = clientsViewModel.cedula_cliente,
                primer_nombre_cliente = clientsViewModel.primer_nombre_cliente,
                segundo_nombre_cliente = clientsViewModel.segundo_nombre_cliente,
                primer_apellido_cliente = clientsViewModel.primer_apellido_cliente,
                segundo_apellido_cliente = clientsViewModel.segundo_apellido_cliente,
                correo_electronico_cliente = clientsViewModel.correo_electronico_cliente,
                estado_cliente = clientsViewModel.estado_cliente
            };
            return Cliente;
        }

        private void LlenarEstados()
        {
            List<EstadoCliente> estados = new List<EstadoCliente>
            {
                new EstadoCliente{nombreEstado="Activo"},
                new EstadoCliente{nombreEstado="Inhabilitado"}
            };

            ViewBag.Estados = estados;

        }

        private void LlenarEstados(string estado)
        {
            List<EstadoCliente> estados = new List<EstadoCliente>
            {
                new EstadoCliente{nombreEstado="Activo"},
                new EstadoCliente{nombreEstado="Inhabilitado"}
            };
            estados.Insert(0, new EstadoCliente { nombreEstado = estado });

            ViewBag.Estados = estados;

        }

        private direction ConvertirDireccion(ClientsViewModel clients)
        {
            sp_Get_Client_X_Cedula_Result Cliente;

            using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
            {
                Cliente = workUnit.clientsDAL.Client(clients.cedula_cliente);
            }

            direction Direccion = new direction
            {
                direccionID = clients.direccionID,
                direccion = clients.direccion,
                relacionID = Cliente.clientID,
                tabla_relacion = "clients"
            };

            return Direccion;
        }

        private direction BorrarDirection(ClientsViewModel Cliente)
        {
            direction Direccion = new direction
            {
                direccionID = Cliente.direccionID
            };

            return Direccion;
        }

        private phone ConvertirTelefono(ClientsViewModel clients)
        {
            sp_Get_Client_X_Cedula_Result Cliente;

            using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
            {
                Cliente = workUnit.clientsDAL.Client(clients.cedula_cliente);
            }

            phone Telefono = new phone
            {
                telefonoID = clients.telefonoID,
                telefono = clients.telefono,
                relacionID = Cliente.clientID,
                tabla_relacion = "clients"
            };

            return Telefono;
        }

        private phone BorrarPhone(ClientsViewModel clients)
        {
            phone Telefono = new phone
            {
                telefonoID = clients.telefonoID
            };

            return Telefono;
        }

        // GET: clients
        public ActionResult Index()
        {
            List<client> lista;
            using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
            {
                lista = workUnit.genericDAL.GetAll().ToList();
            }

            List<ClientsViewModel> listaModel = new List<ClientsViewModel>();
            foreach (var item in lista)
            {
                listaModel.Add(Convertir(item));
            }

            return View(listaModel);
        }

        // GET: clients/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                client Client;
            sp_directions_clients_Result Direccion;
            sp_phones_clients_Result Telefono;

            using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
            {
                Client = workUnit.genericDAL.Get(id);
                Telefono = workUnit.clientsDAL.Telefono(id);
                Direccion = workUnit.clientsDAL.Direccion(id);
            }
            
                return View(Convertir(Client, Telefono, Direccion));
            }
            catch (Exception msj)
            {
                string proveedor = "Detalles Cliente";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "seleccionar a un cliente existente!";
                string exception = msj.Message;
                string redirection = "Create";
                string controller2 = "Clients";

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

        // GET: clients/Create
        public ActionResult Create()
        {
            LlenarEstados();

            return View();
        }


        // POST: clients/Create
        [HttpPost]
        public ActionResult Create(ClientsViewModel clients)
        {
            try
            {
                using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
                {
                    workUnit.genericDAL.Add(Convertir(clients));
                    workUnit.Complete();
                }

                using (WorkUnit<direction> workUnit = new WorkUnit<direction>(new BDContext()))
                {
                    workUnit.genericDAL.Add(ConvertirDireccion(clients));
                    workUnit.Complete();
                }

                using (WorkUnit<phone> workUnit = new WorkUnit<phone>(new BDContext()))
                {
                    workUnit.genericDAL.Add(ConvertirTelefono(clients));
                    workUnit.Complete();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Crear Cliente";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "ingresando la información del cliente en su debido formato!";
                string exception = msj.Message;
                string redirection = "Create";
                string controller2 = "Clients";

                return RedirectToAction("Error", new RouteValueDictionary
                    (new { Controller="Error", Action="Error", proveedor=proveedor,
                    mensaje =mensaje,exception=exception,redirection=redirection,controller2=controller2 }));
            }
        }

        // GET: clients/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                client Client;
                sp_directions_clients_Result Direccion;
                sp_phones_clients_Result Telefono;

                using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
                {
                    Client = workUnit.genericDAL.Get(id);
                    Telefono = workUnit.clientsDAL.Telefono(id);
                    Direccion = workUnit.clientsDAL.Direccion(id);
                }

                LlenarEstados(Client.estado_cliente);

                return View(Convertir(Client, Telefono, Direccion));
            }
            catch (Exception msj)
            {
                string proveedor = "Editar Cliente";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar a un cliente existente y de ingresar los datos en el formato correcto!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Clients";

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

        // POST: clients/Edit/5
        [HttpPost]
        public ActionResult Edit(ClientsViewModel clientsViewModel)
        {
            try
            {
                using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
                {
                    workUnit.genericDAL.Update(Convertir(clientsViewModel));
                    workUnit.Complete();
                }

                using (WorkUnit<direction> workUnit = new WorkUnit<direction>(new BDContext()))
                {
                    workUnit.genericDAL.Update(ConvertirDireccion(clientsViewModel));
                    workUnit.Complete();
                }

                using (WorkUnit<phone> workUnit = new WorkUnit<phone>(new BDContext()))
                {
                    workUnit.genericDAL.Update(ConvertirTelefono(clientsViewModel));
                    workUnit.Complete();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Editar Cliente";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar a un cliente existente y de ingresar los datos en el formato correcto!";
                string exception = msj.Message;
                string redirection = "Edit/"+clientsViewModel.clientID;
                string controller2 = "Clients";

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
        // GET: clients/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                client Client;
                sp_directions_clients_Result Direccion;
                sp_phones_clients_Result Telefono;

                using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
                {
                    Client = workUnit.genericDAL.Get(id);
                    Telefono = workUnit.clientsDAL.Telefono(id);
                    Direccion = workUnit.clientsDAL.Direccion(id);
                }

                return View(Convertir(Client, Telefono, Direccion));
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Cliente";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar a un cliente existente y de ingresar los datos en el formato correcto!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Clients";

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

        // POST: clients/Delete/5
        [HttpPost]
        public ActionResult Delete(ClientsViewModel clientsViewModel)
        {
            try
            {
                using (WorkUnit<client> workUnit = new WorkUnit<client>(new BDContext()))
                {
                    workUnit.genericDAL.Delete(Convertir(clientsViewModel));
                    workUnit.Complete();
                }

                using (WorkUnit<direction> workUnit = new WorkUnit<direction>(new BDContext()))
                {
                    workUnit.genericDAL.Delete(BorrarDirection(clientsViewModel));
                    workUnit.Complete();
                }

                using (WorkUnit<phone> workUnit = new WorkUnit<phone>(new BDContext()))
                {
                    workUnit.genericDAL.Delete(BorrarPhone(clientsViewModel));
                    workUnit.Complete();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Cliente";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "borrando la información de un cliente que no tiene dependencias!";
                string exception = msj.Message;
                string redirection = "Delete/"+clientsViewModel.clientID;
                string controller2 = "Clients";

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
