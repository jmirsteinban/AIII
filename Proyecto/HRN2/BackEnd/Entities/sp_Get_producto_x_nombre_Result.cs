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
    
    public partial class sp_Get_producto_x_nombre_Result
    {
        public int productID { get; set; }
        public string codigo_producto { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public Nullable<decimal> precio_manufactura { get; set; }
        public decimal precio_venta { get; set; }
        public string estado_producto { get; set; }
        public decimal porcentaje_ganancia { get; set; }
        public Nullable<decimal> porcentaje_descuento { get; set; }
    }
}
