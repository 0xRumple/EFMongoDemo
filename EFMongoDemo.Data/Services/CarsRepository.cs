using EFMongoDemo.Core.Models;
using MongoDB.Bson;

namespace EFMongoDemo.Data.Services
{
	public class CarsRepository : DataService<Car, string>
	{
		public CarsRepository(EFMongoDemoDbContext context) : base(context)
		{
		}
	}
}
