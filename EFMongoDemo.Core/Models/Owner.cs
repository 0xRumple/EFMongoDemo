using Microsoft.AspNetCore.Identity;

namespace EFMongoDemo.Core.Models
{
	//[BsonKnownTypes(typeof(Employee), typeof(Manager))]
	public class Owner : IdentityUser, IOwner
	{

		public Owner()
		{
			//Id = ObjectId.GenerateNewId().ToString();
			Name = "";
		}
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public string Id { get; set; }
		public string Name { get; set; }
		public virtual string GetTypeString()
		{
			return GetType().ToString();
		}
	}
}
