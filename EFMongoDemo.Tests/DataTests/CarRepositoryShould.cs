using System.Threading.Tasks;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Data;
using EFMongoDemo.Data.Extensions;
using EFMongoDemo.Data.Services;
using MongoDB.Bson;
using Xunit;

namespace EFMongoDemo.Tests.DataTests
{
    public class CarRepositoryShould
    {
		[Fact]
	    public async Task GetById_JoinCarAndOwner()
	    {
		    var context = _db.NewContext();
		    var myObjId = ObjectId.GenerateNewId();
		    var employeeName = "John";
			var car = new Car {Id = myObjId.ToString(), Owner = new Owner{Name = employeeName } };
		    var carRepo = new CarRepository(context);

		    await carRepo.Add(car);
		    var gottenCar = await carRepo.GetById(myObjId);

		    Assert.Equal(car.Owner.Name, employeeName);
	    }

	    private readonly DbInstance<EFMongoDemoDbContext> _db =
		    new DbInstance<EFMongoDemoDbContext>(options => new EFMongoDemoDbContext(options));
	}
}
