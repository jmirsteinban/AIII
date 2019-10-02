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
    public class TestProducts
    {
        private WorkUnit<product> unit;

        [TestMethod]
        public void AddProduct()
        {
            product Product = new product
            {
                codigo_producto= "HT6E",
                nombre_producto= "Horno turbo aire Digital de 6 bandejas 45x65 electrico 220v",
                descripcion = "Horno turbo aire Digital de 6 bandejas 45x65 electrico 220v",
                cantidad=7,
                precio_manufactura=800000,
                precio_venta=1100000,
                estado_producto="Agotado",
                porcentaje_ganancia=(decimal) 0.35,
                porcentaje_descuento=(decimal) 0.00                
            };

            using (unit = new WorkUnit<product>(new BDContext()))
            {
                unit.genericDAL.Add(Product);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetProduct()
        {
            using (unit = new WorkUnit<product>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateProduct()
        {
            product Product = new product
            {
                productID = 90,
                codigo_producto = "HT7E",
                nombre_producto = "Horno turbo aire Digital de 6 bandejas 45x65 electrico 220v",
                descripcion = "Horno turbo aire Digital de 6 bandejas 45x65 electrico 220v",
                cantidad = 7,
                precio_manufactura = 800000,
                precio_venta = 1100000,
                estado_producto = "Disponible",
                porcentaje_ganancia = (decimal)0.35,
                porcentaje_descuento = (decimal)0.00
            };

            using (unit = new WorkUnit<product>(new BDContext()))
            {
                unit.genericDAL.Delete(Product);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void Deleteproduct()
        {
            product Product = new product
            {
                productID=90,
                codigo_producto = "HT6E",
                nombre_producto = "Horno turbo aire Digital de 6 bandejas 45x65 electrico 220v",
                descripcion = "Horno turbo aire Digital de 6 bandejas 45x65 electrico 220v",
                cantidad = 7,
                precio_manufactura = 800000,
                precio_venta = 1100000,
                estado_producto = "Disponible",
                porcentaje_ganancia = (decimal)0.35,
                porcentaje_descuento = (decimal)0.00
            };

            using (unit = new WorkUnit<product>(new BDContext()))
            {
                unit.genericDAL.Delete(Product);
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
