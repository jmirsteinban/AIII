using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    class SalesDALImpl : ISalesDAL
    {
        protected readonly BDContext context;

        public SalesDALImpl(BDContext _context)
        {
            context = _context;
        }

        public sp_Get_factura_detalle_Result GetFacturaDetalle(int maestroID)
        {
            try
            {
                return context.sp_Get_factura_detalle(maestroID).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public sp_Get_producto_x_nombre_Result GetProducto(string nombreProducto)
        {
            try
            {
                return context.sp_Get_producto_x_nombre(nombreProducto).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
