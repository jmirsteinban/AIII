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

        public EarningsViewModel Convertir(earnings Earning)
        {
            EarningsViewModel earningsViewModel = new EarningsViewModel
            {
                earningID = Earning.earningID,
                earnings_total_mes = Earning.earnings_total_mes,
                conteo_facturas = Earning.conteo_facturas,
                utils_total_mes = Earning.utils_total_mes,
                ano = Earning.ano,
                mes = Earning.mes
            };
            return earningsViewModel;
        }


        public ActionResult Index()
        {

            List<earnings> lista;
            using (WorkUnit<earnings> workUnit = new WorkUnit<earnings>(new BDContext()))
            {
                lista = workUnit.genericDAL.GetAll().ToList();
            }

            List<EarningsViewModel> listaModel = new List<EarningsViewModel>();
            foreach (var item in lista)
            {
                listaModel.Add(Convertir(item));
            }

            return View(listaModel);


        }
    }
}

