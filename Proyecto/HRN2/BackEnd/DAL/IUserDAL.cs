using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IUserDAL
    {
        bool insertar(int idRole, string login);
        bool insertar(string roleName, string login);
        user getUser(string userName);
        user getUser(string userName, string password);
        user getUser(int EmpleadoId);
        user get(int id);
        List<user> getAll();
        bool isUserInRole(string userName, string roleName);
        string[] gerRolesForUser(string userName);
        List<user> getUsuariosRole(string roleName);
        List<Role> listarRoles();
        bool eliminar(string idRole, int idUsuario);
        user ObtenerPorID(int id);
    }
}
