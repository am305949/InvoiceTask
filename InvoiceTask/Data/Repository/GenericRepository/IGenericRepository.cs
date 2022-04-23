using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceTask.Data.Repository.GenericRepository
{
	public interface IGenericRepository<T>
	{
		List<T> GetAll();
		T GetById(Guid _id);
		int Insert(T _obj);
		int Update(Guid _id, T _obj);
		int Delete(Guid _id);
	}
}
