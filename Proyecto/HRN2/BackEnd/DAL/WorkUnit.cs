using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class WorkUnit<TEntity> : IDisposable where TEntity : class
    {
        private readonly BDContext context;
        public IDALGeneric<TEntity> genericDAL;
        public IDALClients clientsDAL;
        public IDALUsers usersDAL;
        public ISalesDAL salesDAL;

        public WorkUnit(BDContext _context){
            context = _context;
            genericDAL = new DALGenericImpl<TEntity>(context);
            clientsDAL = new DALClientsImpl(context);
            usersDAL = new DALUsersImpl(context);
            salesDAL = new SalesDALImpl(context);
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
