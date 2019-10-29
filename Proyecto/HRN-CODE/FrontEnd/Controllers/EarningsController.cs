using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    //Autorizaciones
    //[Authorize(Roles = "Consulta")]

    public class EarningsController : Controller
    {

        public EarningsViewModel Convertir(earning Earning)
        {
            EarningsViewModel earningsViewModel = new EarningsViewModel
            {
                earningID = Earning.earningID,
                earnings_total_mes = Earning.earnings_total_mes,
                conteo_facturas = Earning.conteo_facturas,
                utils_total_mes = Earning.utils_total_mes,
                ano_mes = Earning.ano_mes
            };
            return earningsViewModel;
        }


        public ActionResult Index()
        {

            List<earning> lista;
            using (WorkUnit<earning> workUnit = new WorkUnit<earning>(new BDContext()))
            {
                lista = workUnit.genericDAL.GetAll().ToList();
            }

            List<EarningsViewModel> listaModel = new List<EarningsViewModel>();
            foreach (var item in lista)
            {
                listaModel.Add(Convertir(item));
            }

            return RedirectToAction("Index");


        }
    }
}

