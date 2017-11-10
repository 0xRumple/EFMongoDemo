using System.ComponentModel.DataAnnotations.Schema;
using EFMongoDemo.Core.Models.Entity;
using MongoDB.Bson;

namespace EFMongoDemo.Core.Models
{
	public class Car : IEntity<string>
	{
		public Car()
		{
			Id = ObjectId.GenerateNewId().ToString();
			//Owner = new Employee();
		}
		public string Id { get; set; }
		public string Model { get; set; }
		public int Price { get; set; }
		//public ICollection<Owner> Owners { get; set; }
		public string OwnerId { get; set; }
		//[NotMapped]
		public Owner Owner { get; set; }
	}
}
