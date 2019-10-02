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
    public class TestDirections
    {
        private WorkUnit<direction> unit;

        [TestMethod]
        public void AddDirection()
        {
            direction Direction = new direction
            {
                direccion="Heredia",
                tabla_relacion="clients",
                relacionID=15
            };

            using (unit = new WorkUnit<direction>(new BDContext()))
            {
                unit.genericDAL.Add(Direction);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetDirection()
        {
            using (unit = new WorkUnit<direction>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateDirection()
        {
            direction Direction = new direction
            {
                direccionID=1,
                direccion = "San José",
                tabla_relacion = "clients",
                relacionID = 15
            };

            using (unit = new WorkUnit<direction>(new BDContext()))
            {
                unit.genericDAL.Delete(Direction);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void DeleteDirection()
        {
            direction Direction = new direction
            {
                direccionID=1,
                direccion = "San José",
                tabla_relacion = "clients",
                relacionID = 15
            };

            using (unit = new WorkUnit<direction>(new BDContext()))
            {
                unit.genericDAL.Delete(Direction);
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
