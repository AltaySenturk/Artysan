using Artysan_DAL.Contexts;
using Artysan_DAL.Repositories;
using Artysan_Service.Interfaces;
using Artysan_Service.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ArtysanDbContext _context;
		private bool disposed = false;
		public UnitOfWork(ArtysanDbContext context)  //DI Container
		{
			_context = context;
		}
		public IRepository<T> GetRepository<T>() where T : class
		{
			return new Repository<T>(_context);
		}
		public void Commit()
		{
			_context.SaveChanges();
		}

		public async void CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this); 
		}
	}
}
