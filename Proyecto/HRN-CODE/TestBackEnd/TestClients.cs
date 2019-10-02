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
    public class TestClients
    {
        private WorkUnit<client> unit;

        [TestMethod]
        public void AddClient()
        {
            client Client = new client
            {
                cedula_cliente = "119487125",
                primer_nombre_cliente = "Katerina",
                segundo_nombre_cliente = "Masha",
                primer_apellido_cliente = "Rostova",
                segundo_apellido_cliente = "Keen",
                correo_electronico_cliente = "krostova@gmail.com",
                estado_cliente = "Inhabilitado"
            };

            using (unit = new WorkUnit<client>(new BDContext()))
            {
                unit.genericDAL.Add(Client);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetClient()
        {
            using (unit = new WorkUnit<client>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateClient()
        {
            client Client = new client
            {
                cedula_cliente = "1-1948-7125",
                primer_nombre_cliente = "Katerina",
                segundo_nombre_cliente = "Masha",
                primer_apellido_cliente = "Rostova",
                segundo_apellido_cliente = "Keen",
                correo_electronico_cliente = "krostova@gmail.com",
                estado_cliente = "Inhabilitado"
            };

            using (unit = new WorkUnit<client>(new BDContext()))
            {
                unit.genericDAL.Delete(Client);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void DeleteClient()
        {
            client Client = new client
            {
                cedula_cliente = "119487125",
                primer_nombre_cliente = "Katerina",
                segundo_nombre_cliente = "Masha",
                primer_apellido_cliente = "Rostova",
                segundo_apellido_cliente = "Keen",
                correo_electronico_cliente = "krostova@gmail.com",
                estado_cliente = "Inhabilitado"
            };

            using (unit = new WorkUnit<client>(new BDContext()))
            {
                unit.genericDAL.Delete(Client);
                Assert.AreEqual(true, unit.Complete());
            }
        }                

        [TestMethod]
        public void sp_directions_clients_Result()
        {           
            using (unit = new WorkUnit<client>(new BDContext()))
            {
                unit.clientsDAL.Direccion(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void sp_phones_clients_Result()
        {           
            using (unit = new WorkUnit<client>(new BDContext()))
            {
                unit.clientsDAL.Telefono(2);
                Assert.AreEqual(true, unit.Complete());
            }
        }        

        [TestMethod]
        public void sp_Get_Client_X_Cedula_Result()
        {
            using (unit = new WorkUnit<client>(new BDContext()))
            {
                unit.clientsDAL.Client("1-1747-0663");
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
