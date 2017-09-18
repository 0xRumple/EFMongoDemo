using System.Threading.Tasks;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Data;
using EFMongoDemo.Data.Extensions;
using EFMongoDemo.Data.Services;
using MongoDB.Bson;
using Xunit;

namespace EFMongoDemo.Tests.DataTests
{
	public class DataServiceShould
	{
		[Fact]
		public async Task GetById_UsingObjectId()
		{
			var context = _db.NewContext();
			var myObjId = ObjectId.GenerateNewId();
			var car = new Car {Owner = new Employee{Name = "John"}};
			car.Id = car.Id.Create(myObjId);
			var carRepo = new CarRepository(context);
			await carRepo.Add(car);

			var gottenCar = await carRepo.GetById(myObjId);

			Assert.Equal(gottenCar.Id, car.Id);
		}

		private readonly DbInstance<EFMongoDemoDbContext> _db = 
					new DbInstance<EFMongoDemoDbContext>(options => new EFMongoDemoDbContext(options));
	}
}
