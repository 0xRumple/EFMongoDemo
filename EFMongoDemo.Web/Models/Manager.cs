using MongoDB.Bson;

namespace EFMongoDemo.Web.Models
{
    public class Manager : IOwner
    {
	    public ObjectId Id { get; set; }
	    public string Name { get; set; }

	    public string GetTypeString()
	    {
		    return GetType().ToString();
	    }
    }
}
