using EFMongoDemo.Core.Models.Entity;

namespace EFMongoDemo.Core.Models
{
	public interface IOwner : IEntity<string>
	{
		string Id { get; set; }
		string Name { get; set; }

		string GetTypeString();
	}
}