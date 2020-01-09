using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.Entities
{
	public interface IRepository<T, U> where T: class where U: class
	{
		bool Create(T item);
		IList<T> GetAll();
		IList<T> GetAllWith()
	}
}
