using MongoDB.Bson;

namespace EFMongoDemo.Web.Models
{
	public class Car
	{
		public Car()
		{
			//Owner = new Owner{Id = ObjectId.GenerateNewId()};
			Owner = new Employee();
		}
		public ObjectId Id { get; set; }
		public string Model { get; set; }
	    public int Price { get; set; }
		//public ICollection<Owner> Owners { get; set; }
		public IOwner Owner { get; set; }
	}
}
