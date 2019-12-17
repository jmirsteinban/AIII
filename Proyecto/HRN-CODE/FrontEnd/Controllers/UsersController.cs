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
    [Authorize(Roles = "Administrador")]

    public class UsersController : Controller
    {
        public UsersViewModel Convertir(user User,sp_phones_users_Result telefono,sp_directions_users_Result direccion)
        {
            UsersViewModel usersViewModel = new UsersViewModel
            {
                userID = User.userID,
                cedula_user = User.cedula_user,
                primer_nombre_user = User.primer_nombre_user,
                segundo_nombre_user = User.segundo_nombre_user,
                primer_apellido_user = User.primer_apellido_user,
                segundo_apellido_user = User.segundo_apellido_user,
                usuario = User.usuario,
                contrasena=User.contrasena,
                tipo_user=User.tipo_user,
                estado_user = User.estado_user,
                direccionID=direccion.direccionID,
                direccion=direccion.direccion,
                telefonoID=telefono.telefonoID,
                telefono=telefono.telefono
            };

            return usersViewModel;
        }

        public UsersViewModel Convertir(user User)
        {
            UsersViewModel usersViewModel = new UsersViewModel
            {
                userID = User.userID,
                cedula_user = User.cedula_user,
                primer_nombre_user = User.primer_nombre_user,
                segundo_nombre_user = User.segundo_nombre_user,
                primer_apellido_user = User.primer_apellido_user,
                segundo_apellido_user = User.segundo_apellido_user,
                usuario = User.usuario,
                contrasena=User.contrasena,
                tipo_user=User.tipo_user,
                estado_user = User.estado_user
            };
            return usersViewModel;
        }

        public user Convertir(UsersViewModel usersViewModel)
        {
            user User = new user
            {
                userID = usersViewModel.userID,
                cedula_user = usersViewModel.cedula_user,
                primer_nombre_user = usersViewModel.primer_nombre_user,
                segundo_nombre_user = usersViewModel.segundo_nombre_user,
                primer_apellido_user = usersViewModel.primer_apellido_user,
                segundo_apellido_user = usersViewModel.segundo_apellido_user,
                usuario = usersViewModel.usuario,
                contrasena = usersViewModel.contrasena,
                tipo_user = usersViewModel.tipo_user,
                estado_user = usersViewModel.estado_user
            };
            return User;
        }

        private void LlenarListas()
        {
            List<EstadoCliente> estados = new List<EstadoCliente>
            {
                new EstadoCliente{nombreEstado="Activo"},
                new EstadoCliente{nombreEstado="Inhabilitado"}
            };

            ViewBag.Estados = estados;

            List<Tipo> tipos = new List<Tipo>
            {
                new Tipo{tipoUsuario="Admin"},
                new Tipo{tipoUsuario="Empleado"}
            };

            ViewBag.Tipos = tipos;

        }

        private void LlenarListas(string estado,string tipo)
        {
            List<EstadoCliente> estados = new List<EstadoCliente>
            {
                new EstadoCliente{nombreEstado="Activo"},
                new EstadoCliente{nombreEstado="Inhabilitado"}
            };
            estados.Insert(0, new EstadoCliente { nombreEstado = estado });

            ViewBag.Estados = estados;

            List<Tipo> tipos = new List<Tipo>
            {
                new Tipo{tipoUsuario="Admin"},
                new Tipo{tipoUsuario="Empleado"}
            };

            tipos.Insert(0, new Tipo { tipoUsuario=tipo});

            ViewBag.Tipos = tipos;

        }

        private direction ConvertirDireccion(UsersViewModel users)
        {
            sp_Get_User_X_Cedula_Result Usuario;

            using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
            {
                Usuario = workUnit.usersDAL.User(users.cedula_user);
            }

            direction Direccion = new direction
            {        
                direccionID=users.direccionID,
                direccion=users.direccion,
                relacionID=Usuario.userID,
                tabla_relacion="users"
            };

            return Direccion;
        }

        private direction BorrarDirection(UsersViewModel Usuario)
        {
            direction Direccion = new direction
            {
                direccionID=Usuario.direccionID
            };

            return Direccion;
        }

        private phone ConvertirTelefono(UsersViewModel users)
        {
            sp_Get_User_X_Cedula_Result Usuario;

            using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
            {
                Usuario = workUnit.usersDAL.User(users.cedula_user);
            }

            phone Telefono = new phone
            {
                telefonoID=users.telefonoID,
                telefono=users.telefono,
                relacionID=Usuario.userID,
                tabla_relacion="users"
            };

            return Telefono;
        }

        private phone BorrarPhone(UsersViewModel Usuario)
        {
            phone Telefono = new phone
            {
                telefonoID = Usuario.telefonoID
            };

            return Telefono;
        }

        // GET: users
        public ActionResult Index()
        {
            List<user> lista;
            using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
            {
                lista = workUnit.genericDAL.GetAll().ToList();
            }

            List<UsersViewModel> listaModel = new List<UsersViewModel>();
            foreach (var item in lista)
            {
                listaModel.Add(Convertir(item));
            }

            return View(listaModel);
        }

        // GET: users/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                user User;
                sp_directions_users_Result Direccion;
                sp_phones_users_Result Telefono;

                using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
                {
                    User = workUnit.genericDAL.Get(id);
                    Telefono = workUnit.usersDAL.Telefono(id);
                    Direccion = workUnit.usersDAL.Direccion(id);
                }

                return View(Convertir(User, Telefono, Direccion));
            }
            catch (Exception msj)
            {
                string proveedor = "Detalles Empleado";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "seleccionar a un empleado existente!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Users";

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

        // GET: users/Create
        public ActionResult Create()
        {
            LlenarListas();

            return View();
        }


        // POST: users/Create
        [HttpPost]
        public ActionResult Create(UsersViewModel users)
        {
            bool seguir = true;

            try
            {
                using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
                {
                    workUnit.genericDAL.Add(Convertir(users));
                    seguir=workUnit.Complete();
                }

                if (!seguir)
                {
                    throw new Exception();
                }

                using (WorkUnit<direction> workUnit = new WorkUnit<direction>(new BDContext()))
                {
                    workUnit.genericDAL.Add(ConvertirDireccion(users));
                    workUnit.Complete();
                }

                using (WorkUnit<phone> workUnit = new WorkUnit<phone>(new BDContext()))
                {
                    workUnit.genericDAL.Add(ConvertirTelefono(users));
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
                string proveedor = "Crear Empleado";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegúrese de estar " +
                    " ingresando la información correcta, que no sea duplicada (cédula o número de teléfono) y que haya llenado todos los espacios!";    
                string exception = msj.Message;
                string redirection = "Create";
                string controller2 = "Users";

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

        // GET: users/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                user User;
                sp_directions_users_Result Direccion;
                sp_phones_users_Result Telefono;

                using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
                {
                    User = workUnit.genericDAL.Get(id);
                    Telefono = workUnit.usersDAL.Telefono(id);
                    Direccion = workUnit.usersDAL.Direccion(id);
                }

                LlenarListas(User.estado_user, User.tipo_user);

                return View(Convertir(User, Telefono, Direccion));
            }
            catch (Exception msj)
            {
                string proveedor = "Editar Empleado";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar a un empleado existente y de contar con permisos para realizar el proceso!";
                string exception = msj.Message;
                string redirection = "Edit";
                string controller2 = "Users";

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

        // POST: users/Edit/5
        [HttpPost]
        public ActionResult Edit(UsersViewModel usersViewModel)
        {
            bool seguir = true;

            try
            {
                using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
                {
                    workUnit.genericDAL.Update(Convertir(usersViewModel));
                    seguir=workUnit.Complete();
                }

                if (!seguir)
                {
                    throw new Exception();
                }

                using (WorkUnit<direction> workUnit = new WorkUnit<direction>(new BDContext()))
                {
                    workUnit.genericDAL.Update(ConvertirDireccion(usersViewModel));
                    workUnit.Complete();
                }

                using (WorkUnit<phone> workUnit = new WorkUnit<phone>(new BDContext()))
                {
                    workUnit.genericDAL.Update(ConvertirTelefono(usersViewModel));
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
                string proveedor = "Editar Empleado";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "ingresar los datos en el formato correcto y" +
                    " que no sean duplicados (número de teléfono)!";
                string exception = msj.Message;
                string redirection = "Edit/" + usersViewModel.userID;
                string controller2 = "Users";

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

        // GET: users/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                user User;
                sp_directions_users_Result Direccion;
                sp_phones_users_Result Telefono;

                using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
                {
                    User = workUnit.genericDAL.Get(id);
                    Telefono = workUnit.usersDAL.Telefono(id);
                    Direccion = workUnit.usersDAL.Direccion(id);
                }

                return View(Convertir(User, Telefono, Direccion));
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Empleado";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de " +
                    "seleccionar a un empleado existente!";
                string exception = msj.Message;
                string redirection = "Index";
                string controller2 = "Users";

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

        // POST: users/Delete/5
        [HttpPost]
        public ActionResult Delete(UsersViewModel usersViewModel)
        {
            try
            {
                using (WorkUnit<user> workUnit = new WorkUnit<user>(new BDContext()))
                {
                    workUnit.genericDAL.Delete(Convertir(usersViewModel));
                    workUnit.Complete();
                }

                using (WorkUnit<direction> workUnit = new WorkUnit<direction>(new BDContext()))
                {
                    workUnit.genericDAL.Delete(BorrarDirection(usersViewModel));
                    workUnit.Complete();
                }

                using (WorkUnit<phone> workUnit = new WorkUnit<phone>(new BDContext()))
                {
                    workUnit.genericDAL.Delete(BorrarPhone(usersViewModel));
                    workUnit.Complete();
                }

                return RedirectToAction("Index");
            }
            catch (Exception msj)
            {
                string proveedor = "Borrar Empleado";
                string mensaje = "¡Hubo un error mientras se procesaba su solicitud, asegurese de estar " +
                    "borrando la información de un empleado que no tiene dependencias!";
                string exception = msj.Message;
                string redirection = "Delete/" + usersViewModel.userID;
                string controller2 = "Users";

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