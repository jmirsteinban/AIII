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
    
    public partial class sp_Get_Garantias_Result
    {
        public int compraID { get; set; }
        public int clientID { get; set; }
        public int userID { get; set; }
        public Nullable<System.DateTime> fecha_compra { get; set; }
        public decimal monto_total { get; set; }
        public string estado_factura { get; set; }
        public Nullable<byte> fact_analizada { get; set; }
    }
}