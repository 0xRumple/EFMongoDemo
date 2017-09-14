using System.Threading.Tasks;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Data;
using EFMongoDemo.Data.Extensions;
using EFMongoDemo.Data.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Xunit;

namespace EFMongoDemo.Tests
{
	public class DataServiceShould
	{
		[Fact]
		public async Task GetById_UsingObjectId()
		{
			var context = _db.NewContext();
			var myObjId = ObjectId.GenerateNewId();
			var car = new Car() {Id = myObjId.ToString()};
			var carRepo = new CarsRepository(context);
			await carRepo.Add(car);

			var gottenCar = await carRepo.GetById(myObjId);

			Assert.Equal(gottenCar, car);
		}

		private readonly DbInstance<EFMongoDemoDbContext> _db = 
					new DbInstance<EFMongoDemoDbContext>(options => new EFMongoDemoDbContext(options));
	}
}
