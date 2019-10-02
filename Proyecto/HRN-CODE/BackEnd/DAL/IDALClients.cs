using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IDALClients
    {
        sp_Get_Client_X_Cedula_Result Client(string cedula);
        sp_directions_clients_Result Direccion(int id);
        sp_phones_clients_Result Telefono(int id);
    }
}
