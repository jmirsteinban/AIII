using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models
{
    public class EarningsViewModel
    {
        [Key]
        public int earningID { get; set; }

        [Display(Name = "Venta Total")]
        public decimal earnings_total_mes { get; set; }

        [Display(Name = "Cantidad de Facturas")]
        public int conteo_facturas { get; set; }

        [Display(Name = "Utilidad Total")]
        public Nullable<decimal> utils_total_mes { get; set; }

        [Display(Name = "Año")]
        public string ano { get; set; }

        [Display(Name = "Mes")]
        public string mes { get; set; }


    }
}