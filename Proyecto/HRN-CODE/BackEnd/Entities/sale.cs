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
    
    public partial class sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sale()
        {
            this.sales_x_products = new HashSet<sales_x_products>();
            this.warranties = new HashSet<warranty>();
        }
    
        public int compraID { get; set; }
        public int clientID { get; set; }
        public int userID { get; set; }
        public Nullable<System.DateTime> fecha_compra { get; set; }
        public decimal monto_total { get; set; }
        public string estado_factura { get; set; }
        public Nullable<byte> fact_analizada { get; set; }
    
        public virtual client client { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_x_products> sales_x_products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<warranty> warranties { get; set; }
    }
}
