using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ProductsViewModel
    {
        [Display(Name ="ID Producto")]
        [Key]
        public int productID { get; set; }

        [Display(Name ="Código Producto")]
        public string codigo_producto { get; set; }

        [Display(Name = "Nombre Producto")]
        public string nombre_producto { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Disponibles")]
        public int cantidad { get; set; }

        [Display(Name = "Precio Manufactura")]
        public decimal precio_manufactura { get; set; }

        [Display(Name = "Precio Venta")]
        public decimal precio_venta { get; set; }

        [Display(Name = "Estado")]
        public string estado_producto { get; set; }

        [Display(Name = "Porcentaje Ganancia")]
        public decimal porcentaje_ganancia { get; set; }

        [Display(Name = "Porcentaje Descuento")]
        public decimal porcentaje_descuento { get; set; }
    }

    public class Estado
    {
        public string nombreEstado { get; set; }
    }
}