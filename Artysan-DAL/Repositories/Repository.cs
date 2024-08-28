using Artysan_DAL.Contexts;
using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ArtysanDbContext _context;
		private DbSet<T> _dbSet;

		public Repository(ArtysanDbContext context)
		{
			_context = context;         
			_dbSet = _context.Set<T>(); 
		}
		public async Task Add(T entity)
		{
			await _dbSet.AddAsync(entity);
			
		}
        //public void Update(Event eventToUpdate)
        //{
        //	var existingEvent = _context.Events.Find(eventToUpdate.Id);
        //	if (existingEvent != null)
        //	{
        //		_context.Entry(existingEvent).CurrentValues.SetValues(eventToUpdate);
        //	}
        //}
		public void Update(int id)
		{
            var entity = _dbSet.Find(id);
            _dbSet.Update(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            
        }
        public void Delete(int id)
		{
			var entity = _dbSet.Find(id);
			_dbSet.Remove(entity);
			
		}
		public void Delete(T entity)
		{
			if (entity.GetType().GetProperty("IsDeleted") != null)
			{
				entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);  
				_dbSet.Update(entity);
			}
			else
			{
				_dbSet.Remove(entity);
			}
			//_context.SaveChanges();
		}
		public async Task<T> Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = _dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = _dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (orderby != null)
			{
				query = orderby(query);
			}
			foreach (var tablo in includes)
			{
				query = query.Include(tablo);
			}
			return await query.ToListAsync();
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync(); 
		}
		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
       
    }
}
