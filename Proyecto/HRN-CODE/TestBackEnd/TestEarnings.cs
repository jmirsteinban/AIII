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
    public class TestEarnings
    {
        private WorkUnit<earning> unit;

        [TestMethod]
        public void AddEarning()
        {
            earning Earning = new earning
            {
                conteo_facturas=50,
                earnings_total_mes=5000000,
                fecha_reporte=DateTime.Now
            };

            using (unit = new WorkUnit<earning>(new BDContext()))
            {
                unit.genericDAL.Add(Earning);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void GetEarning()
        {
            using (unit = new WorkUnit<earning>(new BDContext()))
            {
                unit.genericDAL.Get(1);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void UpdateEarning()
        {
            earning Earning = new earning
            {
                conteo_facturas = 51,
                earnings_total_mes = 5600000,
                fecha_reporte = DateTime.Now
            };

            using (unit = new WorkUnit<earning>(new BDContext()))
            {
                unit.genericDAL.Delete(Earning);
                Assert.AreEqual(true, unit.Complete());
            }
        }

        [TestMethod]
        public void DeleteEarning()
        {
            earning Earning = new earning
            {
                conteo_facturas = 51,
                earnings_total_mes = 5600000,
                fecha_reporte = DateTime.Now
            };

            using (unit = new WorkUnit<earning>(new BDContext()))
            {
                unit.genericDAL.Delete(Earning);
                Assert.AreEqual(true, unit.Complete());
            }
        }
    }
}
