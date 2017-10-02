using System.Threading.Tasks;
using EFMongoDemo.Core.Models;

namespace EFMongoDemo.Data.Services
{
    public class OwnerRepository : DataService<Owner, string>
	{
		public OwnerRepository(EFMongoDemoDbContext context) : base(context)
		{
		}

		public override async Task<Owner> Add(Owner entity)
		{
			Context.Users.Add(entity);
			await CommitChanges();

			return entity;
		}
	}
}
