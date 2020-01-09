using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.Entities
{
	public interface IRepository<T> where T : class
	{
		bool Create(T item);
		IList<T> GetAll(bool dependencies = false);
		bool FindById(int id);
		bool FindByName(string name);
		bool Update(T item);
		bool Delete(T item);
		bool DeleteById(int id);
	}
}
