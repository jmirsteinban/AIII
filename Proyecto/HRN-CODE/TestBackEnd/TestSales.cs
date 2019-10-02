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
    public class TestSales
    {
        private WorkUnit<sale> unit;

        [TestMethod]
        public void sp_Get_factura_detalle_Result()
        {
            using (unit = new WorkUnit<sale>(new BDContext()))
            {
                unit.salesDAL.GetFacturaDetalle(2);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void sp_Get_producto_x_nombre_Result()
        {
            using (unit = new WorkUnit<sale>(new BDContext()))
            {
                unit.salesDAL.GetProducto("Horno turbo aire Digital de 5 bandejas 45x65 electrico 220v");
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UltimoID()
        {
            using (unit = new WorkUnit<sale>(new BDContext()))
            {
                unit.salesDAL.ultimoID();
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
