using EFMongoDemo.Data.Extensions;
using EFMongoDemo.Tests.DataTests;
using MongoDB.Bson;
using Xunit;

namespace EFMongoDemo.Tests.CoreTests
{
    public class EntityShould
    {
		[Fact]
		public void GetEntityId_AsObjectIdString()
		{
			var tempEntity = new TempEntity();
			var objId = ObjectId.GenerateNewId();

			tempEntity.Id = tempEntity.Id.Create(objId);

			Assert.Equal(tempEntity.Id, objId.ToString());
		}
	}
}