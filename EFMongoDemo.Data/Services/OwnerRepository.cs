using EFMongoDemo.Core.Models;

namespace EFMongoDemo.Data.Services
{
    public class OwnerRepository : DataService<Owner, string>
	{
		public OwnerRepository(EFMongoDemoDbContext context) : base(context)
		{
		}
	}
}
