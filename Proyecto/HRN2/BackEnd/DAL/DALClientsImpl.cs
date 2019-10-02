using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    class DALClientsImpl : IDALClients
    {

        protected readonly BDContext context;

        public DALClientsImpl(BDContext _context)
        {
            context = _context;
        }

        public sp_directions_clients_Result Direccion(int id)
        {
            try
            {
                return context.sp_directions_clients(id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public sp_phones_clients_Result Telefono(int id)
        {
            try
            {
                return context.sp_phones_clients(id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public sp_Get_Client_X_Cedula_Result Client(string cedula)
        {
            try
            {
                return context.sp_Get_Client_X_Cedula(cedula).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
