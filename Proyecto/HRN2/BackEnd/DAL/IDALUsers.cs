using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IDALUsers
    {
        sp_Get_User_X_Cedula_Result User(string cedula);
        sp_directions_users_Result Direccion(int id);
        sp_phones_users_Result Telefono(int id);
    }
}
