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
    public class TestWarranties
    {
        private WorkUnit<warranty> unit;

        [TestMethod]
        public void Addwarranty()
        {
            warranty Warranty = new warranty
            {
                compraID=1,
                estado_warranty="Aplicable",
                warrantyID=1                
            };

            using (unit = new WorkUnit<warranty>(new BDContext()))
            {
                unit.genericDAL.Add(Warranty);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetWarranty()
        {
            using (unit = new WorkUnit<warranty>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateWarranty()
        {
            warranty Warranty = new warranty
            {
                compraID = 2,
                estado_warranty = "Vencida",
                warrantyID = 1
            };

            using (unit = new WorkUnit<warranty>(new BDContext()))
            {
                unit.genericDAL.Delete(Warranty);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void DeleteWarranty()
        {
            warranty Warranty = new warranty
            {
                compraID = 2,
                estado_warranty = "Vencida",
                warrantyID = 1
            };

            using (unit = new WorkUnit<warranty>(new BDContext()))
            {
                unit.genericDAL.Delete(Warranty);
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
