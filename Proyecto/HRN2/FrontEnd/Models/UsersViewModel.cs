using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class UsersViewModel
    {
        [Display(Name ="ID de Usuario")]
        [Key]
        public int userID { get; set; }

        [Display(Name ="Cédula Empleado")]
        public string cedula_user { get; set; }

        [Display(Name = "Primer Nombre")]
        public string primer_nombre_user { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string segundo_nombre_user { get; set; }

        [Display(Name = "Primer Apellido")]
        public string primer_apellido_user { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string segundo_apellido_user { get; set; }

        [Display(Name = "Nombre Usuario")]
        public string usuario { get; set; }

        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public string tipo_user { get; set; }

        [Display(Name = "Estado")]
        public string estado_user { get; set; }

        public int telefonoID { get; set; }
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        public int direccionID { get; set; }
        [Display(Name ="Dirección")]
        public string direccion { get; set; }
    }

    public class Tipo
    {
        public string tipoUsuario { get; set; }
    }
}