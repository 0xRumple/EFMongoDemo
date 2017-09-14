using System;
using System.Linq;
using System.Threading.Tasks;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Core.Models.Entity;
using EFMongoDemo.Data.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace EFMongoDemo.Data.Extensions
{
    public static class DataServiceExtensions
    {
		public static async Task<TEntity> GetById<TEntity, TId>
			(this DataService<TEntity, TId> dataService, ObjectId id)
			where TEntity : class, IEntity<TId>
		{
			return await dataService.GetById(id.ToString());
		}

	    public static async Task Delete<TEntity, TId>
			(this DataService<TEntity, TId> dataService, ObjectId id)
		    where TEntity : class, IEntity<TId>
	    {
		    await dataService.Delete(id.ToString());
	    }
	}
}
