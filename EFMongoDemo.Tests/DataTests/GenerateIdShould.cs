using EFMongoDemo.Data;
using MongoDB.Bson;
using Xunit;

namespace EFMongoDemo.Tests.DataTests
{
    public class GenerateIdShould
    {
	    [Fact]
	    public void MakeValidId_AsString()
	    {
		    var id = ObjectId.GenerateNewId();

		    Assert.Equal(id.ToString().Length, 24);
	    }

	  //  [Fact]
	  //  public async Task Convert32ObjectIdString_AsObjectIdFormat()
	  //  {
			//var context = _db.NewContext();
		 //   var carRepo = new CarRepository(context);
		 //   var car = new Car {Model = "Benz", Owner = new Employee {Name = "John"}, Price = 9999};

		 //   await carRepo.Add(car);

			//Assert.Equal(car.Id.Length, 24);
			//Console.WriteLine(car.Id);
	  //  }

	    private readonly DbInstance<EFMongoDemoDbContext> _db =
		    new DbInstance<EFMongoDemoDbContext>(options => new EFMongoDemoDbContext(options));
	}
}
