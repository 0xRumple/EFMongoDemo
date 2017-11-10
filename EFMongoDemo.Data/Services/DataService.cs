using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFMongoDemo.Core.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFMongoDemo.Data.Services
{
	public abstract class DataService<TEntity, TId>
		where TEntity : class, IEntity<TId>
	{
		protected DataService(EFMongoDemoDbContext context)
		{
			Context = context;
			DbSet = Context.Set<TEntity>();
		}

		public virtual IQueryable<TEntity> GetAll()
		{
			return DbSet.AsQueryable();
		}

		public virtual async Task<TEntity> Add(TEntity entity)
		{
			Context.Add(entity);
			await CommitChanges();

			return entity;
		}

		public virtual async Task<TEntity> GetById(TId id)
		{
			TEntity result = await DbSet
				.SingleOrDefaultAsync(m => EqualityComparer<TId>.Default.Equals(m.Id, id));

			return result;
			//return await _dbSet.FindAsync(id);
		}

		public virtual async Task<TEntity> Update(TEntity entity)
		{
			Context.Update(entity);
			await CommitChanges();

			return entity;
		}

		public virtual async Task Delete(TId id)
		{
			var entity = await GetById(id);
			DbSet.Remove(entity);
			await CommitChanges();
		}

		public virtual async Task<bool> EntityExists(TId entityId)
		{
			var result = await GetById(entityId) != null;
			return result;
		}

		internal async Task CommitChanges()
		{
			await Context.SaveChangesAsync();
		}

		internal readonly EFMongoDemoDbContext Context;
		internal readonly DbSet<TEntity> DbSet;
	}
}