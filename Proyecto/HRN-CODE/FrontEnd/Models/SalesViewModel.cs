using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class SalesViewModel
    {
        [Display(Name ="ID de Compra")]
        [Key]
        public int compraID { get; set; }
        [Display(Name = "ID Cliente")]
        public int clientID { get; set; }
        [Display(Name = "Cedula Cliente")]
        public string cedula_cliente { get; set; }
        [Display(Name = "ID Usuario")]
        public int userID { get; set; }
        [Display(Name = "Cédula Usuario")]
        public string cedula_user { get; set; }
        [Display(Name = "Fecha Compra")]
        [DataType(DataType.DateTime)]
        public System.DateTime fecha_compra { get; set; }
        [Display(Name = "Monto Total")]
        public decimal monto_total { get; set; }
        [Display(Name = "Estado Factura")]
        public string estado_factura { get; set; }

        [Display(Name = "ID Detalle")]
        public int compraID_detalle { get; set; }
        [Display(Name ="Relación a Sales")]
        public int productID { get; set; }
        [Display(Name = "Nombre Producto")]
        public string nombre_producto { get; set; }
        [Display(Name = "Cantidad Producto")]
        public int cantidad_producto { get; set; }
        [Display(Name = "Precio Unitario")]
        public decimal precio_factura_d { get; set; }

        //Para la vista de Details
        public List<Producto> productosDetalle { get; set; }
    }

    public class Producto
    {
        public string productName { get; set; }
        public string cedCliente { get; set; }
        public string cedUsuario { get; set; }
        public string estado { get; set; }
        public int cantProd { get; set; }
        public decimal precio_factura_d { get; set; }
    }

}