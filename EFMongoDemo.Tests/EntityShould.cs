using System.Threading.Tasks;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Data.Extensions;
using MongoDB.Bson;
using Xunit;

namespace EFMongoDemo.Tests
{
    public class EntityShould
    {
		[Fact]
		public void GetEntityId_AsObjectIdString()
		{
			var car = new Car();
			var objId = ObjectId.GenerateNewId();

			car.Id = car.Id.Create(objId);

			Assert.Equal(car.Id, objId.ToString());
		}
	}
}