using MongoDB.Bson;

namespace EFMongoDemo.Core.Models
{
	public class Owner : IOwner
	{
		protected Owner()
		{
			Id = ObjectId.GenerateNewId().ToString();
			Name = "";
		}
		public string Id { get; set; }
		public string Name { get; set; }
		public virtual string GetTypeString()
		{
			return GetType().ToString();
		}
	}
}
