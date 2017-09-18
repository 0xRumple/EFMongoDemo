using EFMongoDemo.Core.Models.Entity;

namespace EFMongoDemo.Tests.DataTests
{
    public class TempEntity : IEntity<string>
    {
	    public string Id { get; set; }
    }
}
