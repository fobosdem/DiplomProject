using DataBaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.Repository
{
	public class EntitiesContext<T> : DbContext where T : class
	{

		public bool Create(T item)
		{
			throw new NotImplementedException();
		}

		public bool Delete(T item)
		{
			throw new NotImplementedException();
		}

		public bool DeleteById(int id)
		{
			throw new NotImplementedException();
		}

		public bool FindById(int id)
		{
			throw new NotImplementedException();
		}

		public bool FindByName(string name)
		{
			throw new NotImplementedException();
		}

		public IList<T> GetAll(bool dependencies = false)
		{
			throw new NotImplementedException();
		}

		public bool Update(T item)
		{
			throw new NotImplementedException();
		}
	}
}
