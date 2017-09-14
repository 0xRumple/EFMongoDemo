using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFMongoDemo.Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

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

		public virtual async Task<List<TEntity>> GetAll()
		{
			return await DbSet.ToListAsync();
		}

		public virtual async Task<TEntity> Add(TEntity entity)
		{
			Context.Add(entity);
			await CommitChanges();

			return entity;
		}

		/// <summary>
		/// Get entity by id
		/// </summary>
		/// <param name="id">string id type</param>
		/// <returns></returns>
		public virtual async Task<TEntity> GetById(string id)
		{
			TEntity result = null;

			result = await DbSet
				.SingleOrDefaultAsync(m => m.Id as string == id);

			return result;
			//return await _dbSet.FindAsync(id);
		}

		public virtual async Task<TEntity> Update(TEntity entity)
		{
			Context.Update(entity);
			await CommitChanges();

			return entity;
		}

		public virtual async Task Delete(string id)
		{
			var entity = await GetById(id);
			DbSet.Remove(entity);
			await CommitChanges();
		}

		public virtual async Task<bool> EntityExists(string entityId)
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