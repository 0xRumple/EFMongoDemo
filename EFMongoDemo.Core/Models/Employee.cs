namespace EFMongoDemo.Core.Models
{
	public class Employee : IOwner
	{
		public Employee()
		{
			//Id = ObjectId.GenerateNewId();
			Name = "";
		}
		public string Id { get; set; }
		public string Name { get; set; }


		public string GetTypeString()
		{
			return GetType().ToString();
		}
	}
}