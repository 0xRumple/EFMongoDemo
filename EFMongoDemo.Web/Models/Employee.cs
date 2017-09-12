using MongoDB.Bson;

namespace EFMongoDemo.Web.Models
{
	public class Employee : IOwner
	{
		public Employee()
		{
			Id = ObjectId.GenerateNewId();
			Name = "";
		}
		public ObjectId Id { get; set; }
		public string Name { get; set; }


		public string GetTypeString()
		{
			return GetType().ToString();
		}
	}
}