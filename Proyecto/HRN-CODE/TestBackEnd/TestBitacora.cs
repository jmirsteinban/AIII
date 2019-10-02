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
    public class TestBitacora
    {
        private WorkUnit<bitacora> unit;

        [TestMethod]
        public void AddBitacora()
        {
            bitacora Bitacora = new bitacora
            {
                usuario="slherra",
                accion="DeletePrueba",
                fecha_hora=DateTime.Now
            };

            using (unit = new WorkUnit<bitacora>(new BDContext()))
            {
                unit.genericDAL.Add(Bitacora);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetBitacora()
        {
            using (unit = new WorkUnit<bitacora>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateBitacora()
        {
            bitacora Bitacora = new bitacora
            {
                registroID=5,
                usuario = "slherra",
                accion = "Delete",
                fecha_hora = DateTime.Now
            };

            using (unit = new WorkUnit<bitacora>(new BDContext()))
            {
                unit.genericDAL.Delete(Bitacora);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void DeleteBitacora()
        {
            bitacora Bitacora = new bitacora
            {
                registroID=5,
                usuario = "slherra",
                accion = "Delete",
                fecha_hora = DateTime.Now
            };

            using (unit = new WorkUnit<bitacora>(new BDContext()))
            {
                unit.genericDAL.Delete(Bitacora);
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
