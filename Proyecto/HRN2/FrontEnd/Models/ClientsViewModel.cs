using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ClientsViewModel
    {
        [Key]        
        public int clientID { get; set; }
        [Display(Name ="Cédula Cliente")]
        [Required]
        public string cedula_cliente { get; set; }
        [Display(Name ="Primer Nombre")]
        [Required]
        public string primer_nombre_cliente { get; set; }
        [Display(Name = "Segundo Nombre")]
        public string segundo_nombre_cliente { get; set; }
        [Display(Name = "Primer Apellido")]
        [Required]
        public string primer_apellido_cliente { get; set; }
        [Display(Name = "Segundo Apellido")]
        [Required]
        public string segundo_apellido_cliente { get; set; }
        [Display(Name = "Correo Electrónico")]
        [Required]
        public string correo_electronico_cliente { get; set; }
        [Display(Name = "Estado")]
        public string estado_cliente { get; set; }

        public int telefonoID { get; set; }
        [Display(Name = "Teléfono")]
        [Required]
        public string telefono { get; set; }

        public int direccionID { get; set; }
        [Display(Name ="Dirección")]
        [Required]
        public string direccion { get; set; }
    }

    public class EstadoCliente
    {
        public string nombreEstado { get; set; }
    }
}