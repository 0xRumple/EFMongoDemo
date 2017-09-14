using EFMongoDemo.Core.Models.Entity;

namespace EFMongoDemo.Core.Models
{
	public class Car : IEntity<string>
	{
		public Car()
		{
			Owner = new Employee();
		}
		public string Id { get; set; }
		public string Model { get; set; }
		public int Price { get; set; }
		//public ICollection<Owner> Owners { get; set; }
		public Employee Owner { get; set; }
	}
}
