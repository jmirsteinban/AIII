using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface ISalesDAL
    {
        sp_Get_factura_detalle_Result GetFacturaDetalle(int maestroID);

        sp_Get_producto_x_nombre_Result GetProducto(string nombreProducto);
              
    }
}
