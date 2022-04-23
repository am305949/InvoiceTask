using InvoiceTask.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTask.Data.Repository.GenericRepository
{
	public class GenericRepository<T> : IGenericRepository<T>
    where T : class
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }


        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid _id)
        {
            return _context.Set<T>().Find(_id);
        }

        public virtual int Delete(Guid _id)
        {
            var entityToDelete = GetById(_id);
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
            }
            return _context.SaveChanges();
        }

        public int Insert(T _obj)
        {
            _context.Set<T>().Add(_obj);
            return _context.SaveChanges();
        }

        public virtual int Update(Guid _id, T _obj)
        {
            return 0;
        }

    }
}