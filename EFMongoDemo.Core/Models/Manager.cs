using EFMongoDemo.Core.Models.Entity;

namespace EFMongoDemo.Core.Models
{
    public class Manager : IOwner
    {
	    public string Id { get; set; }
	    public string Name { get; set; }

	    public string GetTypeString()
	    {
		    return GetType().ToString();
	    }
    }
}
