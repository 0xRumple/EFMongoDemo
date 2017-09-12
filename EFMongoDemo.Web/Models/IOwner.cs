using MongoDB.Bson;

namespace EFMongoDemo.Web.Models
{
	public interface IOwner
	{
		ObjectId Id { get; set; }
		string Name { get; set; }

		string GetTypeString();
	}
}