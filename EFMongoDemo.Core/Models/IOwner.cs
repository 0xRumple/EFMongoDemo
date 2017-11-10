using EFMongoDemo.Core.Models.Entity;
using MongoDB.Bson;

namespace EFMongoDemo.Core.Models
{
	public interface IOwner : IEntity<ObjectId>
	{
		string Name { get; set; }
		string GetTypeString();
	}
}