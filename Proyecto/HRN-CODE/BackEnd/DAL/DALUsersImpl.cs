using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class DALUsersImpl : IDALUsers
    {
        protected readonly BDContext context;

        public DALUsersImpl(BDContext _context)
        {
            context = _context;
        }

        public sp_directions_users_Result Direccion(int id)
        {
            try
            {
                return context.sp_directions_users(id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public sp_phones_users_Result Telefono(int id)
        {
            try
            {
                return context.sp_phones_users(id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public sp_Get_User_X_Cedula_Result User(string cedula)
        {
            try
            {
                return context.sp_Get_User_X_Cedula(cedula).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
