//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class earning
    {
        public int earningID { get; set; }
        public decimal earnings_total_mes { get; set; }
        public int conteo_facturas { get; set; }
        public Nullable<decimal> utils_total_mes { get; set; }
        public string ano_mes { get; set; }
    }
}
