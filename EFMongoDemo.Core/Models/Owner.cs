using Blueshift.Identity.MongoDB;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;

namespace EFMongoDemo.Core.Models
{
	//[BsonKnownTypes(typeof(Employee), typeof(Manager))]
	public class Owner : MongoDbIdentityUser, IOwner
	{

		public Owner()
		{
			//Id = ObjectId.GenerateNewId().ToString();
			Name = "";
		}
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public new string Id
		{
			get { return base.Id.ToString(); }
			set { }
		}

		public string Name { get; set; }
		public virtual string GetTypeString()
		{
			return GetType().ToString();
		}
	}
}
