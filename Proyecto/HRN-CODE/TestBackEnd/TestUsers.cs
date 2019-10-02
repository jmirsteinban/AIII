using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBackEnd
{
    [TestClass]
    public class TestUsers
    {
        private WorkUnit<user> unit;

        [TestMethod]
        public void AddUser()
        {
            user User = new user
            {
                cedula_user = "119487125",
                primer_nombre_user = "Katerina",
                segundo_nombre_user = "Masha",
                primer_apellido_user = "Rostova",
                segundo_apellido_user = "Keen",
                contrasena="123456",
                usuario="Krostova",
                tipo_user="Empleado",
                estado_user = "Inhabilitado"
            };

            using (unit = new WorkUnit<user>(new BDContext()))
            {
                unit.genericDAL.Add(User);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetUser()
        {
            using (unit = new WorkUnit<user>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateUser()
        {
            user User = new user
            {
                cedula_user = "1-1948-7125",
                primer_nombre_user = "Katerina",
                segundo_nombre_user = "Masha",
                primer_apellido_user = "Rostova",
                segundo_apellido_user = "Keen",
                contrasena = "123456",
                usuario = "Krostova",
                tipo_user = "Empleado",
                estado_user = "Activo"
            };

            using (unit = new WorkUnit<user>(new BDContext()))
            {
                unit.genericDAL.Delete(User);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void DeleteUser()
        {
            user user = new user
            {
                cedula_user = "1-1948-7125",
                primer_nombre_user = "Katerina",
                segundo_nombre_user = "Masha",
                primer_apellido_user = "Rostova",
                segundo_apellido_user = "Keen",
                contrasena = "123456",
                usuario = "Krostova",
                tipo_user = "Empleado",
                estado_user = "Activo"
            };

            using (unit = new WorkUnit<user>(new BDContext()))
            {
                unit.genericDAL.Delete(user);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void sp_directions_users_Result()
        {
            using (unit = new WorkUnit<user>(new BDContext()))
            {
                unit.usersDAL.Direccion(2);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void sp_phones_users_Result()
        {
            using (unit = new WorkUnit<user>(new BDContext()))
            {
                unit.usersDAL.Telefono(2);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void sp_Get_User_X_Cedula_Result()
        {
            using (unit = new WorkUnit<user>(new BDContext()))
            {
                unit.usersDAL.User("1-1747-0663");
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
