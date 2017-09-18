using EFMongoDemo.Core.Models.Entity;
using MongoDB.Bson;

namespace EFMongoDemo.Core.Models
{
	public interface IOwner : IEntity<string>
	{
		string Name { get; set; }
		string GetTypeString();
	}
}