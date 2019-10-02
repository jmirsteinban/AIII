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
    public class TestSales_x_sales_x_productss
    {
        private WorkUnit<sales_x_products> unit;

        [TestMethod]
        public void AddSales_x_products()
        {
            sales_x_products Sales_x_products = new sales_x_products
            {
                compraID=15,
                precio_factura_d=1200000,
                productID=15
            };

            using (unit = new WorkUnit<sales_x_products>(new BDContext()))
            {
                unit.genericDAL.Add(Sales_x_products);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetSales_x_products()
        {
            using (unit = new WorkUnit<sales_x_products>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateSales_x_products()
        {
            sales_x_products Sales_x_products = new sales_x_products
            {
                compraID_detalle = 10,
                compraID = 15,
                precio_factura_d = 1200000,
                productID = 15
            };

            using (unit = new WorkUnit<sales_x_products>(new BDContext()))
            {
                unit.genericDAL.Delete(Sales_x_products);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void Deletesales_x_products()
        {
            sales_x_products Sales_x_products = new sales_x_products
            {
                compraID_detalle=10,
                compraID = 15,
                precio_factura_d = 1200000,
                productID = 15
            };

            using (unit = new WorkUnit<sales_x_products>(new BDContext()))
            {
                unit.genericDAL.Delete(Sales_x_products);
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
