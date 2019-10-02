using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class UserDALImpl : IUserDAL
    {

        private BDContext context;
        public bool eliminar(string idRole, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public string[] gerRolesForUser(string userName)
        {
            string[] result;
            using (context = new BDContext())
            {
                result = context.sp_getRolesForUser(userName).ToArray();
            }


            return result;
        }

        public user get(int id)
        {
            throw new NotImplementedException();
        }

        public List<user> getAll()
        {
            throw new NotImplementedException();
        }

        public user getUser(string userName)
        {
            try
            {
                user resultado;
                using (WorkUnit<user> unidad = new WorkUnit<user>(new BDContext()))
                {
                    Expression<Func<user, bool>> consulta = (u => u.usuario.Equals(userName));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public user getUser(string userName, string password)
        {
            try
            {
                user resultado;
                using (WorkUnit<user> unidad = new WorkUnit<user>(new BDContext()))
                {
                    Expression<Func<user, bool>> consulta = (u => u.usuario.Equals(userName) && u.contrasena.Equals(password));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public user getUser(int EmpleadoId)
        {
            throw new NotImplementedException();
        }

        public List<user> getUsuariosRole(string roleName)
        {
            List<user> result = new List<user>();
            List<string> lista;
            using (context = new BDContext())
            {
                lista = context.sp_getUsuariosRole(roleName).ToList();
                user user;
                foreach (var item in lista)
                {
                    user = this.getUser(item);
                    result.Add(user);
                }

            }


            return result;
        }

        public bool insertar(int idRole, string login)
        {
            throw new NotImplementedException();
        }

        public bool insertar(string roleName, string login)
        {
            throw new NotImplementedException();
        }

        public bool isUserInRole(string userName, string roleName)
        {
            bool result = false;


            using (context = new BDContext())
            {
                result = (bool)context.sp_isUserInRole(userName, roleName).First();
                //  result  = (bool)context.sp_isUserInRole(userName, roleName).FirstOrDefault();

            }

            return result;
        }

        public List<Role> listarRoles()
        {
            throw new NotImplementedException();
        }

        public user ObtenerPorID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
