using System.Threading.Tasks;
using EFMongoDemo.Core.Models.Entity;
using EFMongoDemo.Data.Services;
using MongoDB.Bson;

namespace EFMongoDemo.Data.Extensions
{
	public static class DataServiceExtensions
	{
		public static async Task<TEntity> GetById<TEntity>
			(this DataService<TEntity, string> dataService, ObjectId id)
			where TEntity : class, IEntity<string>
		{
			return await dataService.GetById(id.ToString());
		}

		public static async Task Delete<TEntity>
			(this DataService<TEntity, string> dataService, ObjectId id)
			where TEntity : class, IEntity<string>
		{
			await dataService.Delete(id.ToString());
		}

		public static async Task<bool> EntityExists<TEntity>
			(this DataService<TEntity, string> dataService, ObjectId id)
			where TEntity : class, IEntity<string>
		{
			return await dataService.EntityExists(id.ToString());
		}

		public static async Task<TEntity> GetById<TEntity>
			(this DataService<TEntity, ObjectId> dataService, string id)
			where TEntity : class, IEntity<ObjectId>
		{
			return await dataService.GetById(new ObjectId(id));
		}

		public static async Task Delete<TEntity>
			(this DataService<TEntity, ObjectId> dataService, string id)
			where TEntity : class, IEntity<ObjectId>
		{
			await dataService.Delete(new ObjectId(id));
		}

		public static async Task<bool> EntityExists<TEntity>
			(this DataService<TEntity, ObjectId> dataService, string id)
			where TEntity : class, IEntity<ObjectId>
		{
			return await dataService.EntityExists(new ObjectId(id));
		}
	}
}
