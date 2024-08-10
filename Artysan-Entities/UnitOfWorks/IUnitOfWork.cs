using Artysan_Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Entities.UnitOfWorks
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<T> GetRepository<T>() where T : class;

		void Commit();  

		void CommitAsync();
	}
}
