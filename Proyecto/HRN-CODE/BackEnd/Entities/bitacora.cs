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
    
    public partial class bitacora
    {
        public int registroID { get; set; }
        public string usuario { get; set; }
        public string accion { get; set; }
        public Nullable<System.DateTime> fecha_hora { get; set; }
    }
}
