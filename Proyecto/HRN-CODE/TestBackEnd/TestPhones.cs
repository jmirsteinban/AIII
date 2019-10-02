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
    public class TestPhones
    {
        private WorkUnit<phone> unit;

        [TestMethod]
        public void AddPhone()
        {
            phone Phone = new phone
            {
                telefono="8457-1254",
                tabla_relacion="clients",
                relacionID=12
            };

            using (unit = new WorkUnit<phone>(new BDContext()))
            {
                unit.genericDAL.Add(Phone);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void Getphone()
        {
            using (unit = new WorkUnit<phone>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void Updatephone()
        {
            phone Phone = new phone
            {
                telefonoID=1,
                telefono = "8457-1251",
                tabla_relacion = "clients",
                relacionID = 12
            };

            using (unit = new WorkUnit<phone>(new BDContext()))
            {
                unit.genericDAL.Delete(Phone);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void Deletephone()
        {
            phone Phone = new phone
            {
                telefonoID = 1,
                telefono = "8457-1251",
                tabla_relacion = "clients",
                relacionID = 12
            };

            using (unit = new WorkUnit<phone>(new BDContext()))
            {
                unit.genericDAL.Delete(Phone);
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
