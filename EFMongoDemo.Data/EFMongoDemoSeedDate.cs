using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EFMongoDemo.Core.Enums;
using EFMongoDemo.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EFMongoDemo.Data
{
	public class EFMongoDemoSeedDate
	{
		public EFMongoDemoSeedDate(EFMongoDemoDbContext context,
									UserManager<Owner> userManager,
									RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task ClearDatabase()
		{
			await Clear(_context.Users);
			await Clear(_context.UserClaims);
			await Clear(_context.UserLogins);
			await Clear(_context.UserRoles);
			await Clear(_context.UserTokens);
			await Clear(_context.Roles);
			await Clear(_context.RoleClaims);
			await Clear(_context.Cars);
			//await Clear(_context.Owners);
			await _context.SaveChangesAsync();
		}

		public static async Task Clear<T>(DbSet<T> dbSet) where T : class
		{
			dbSet.RemoveRange(dbSet);
			await Task.Yield();
		}

		public async Task EnsureSeedData()
		{
			//await AddRoles();
			await AddAdminAccount();
		}

		private async Task AddAdminAccount()
		{
			var adminEmail = "admin@demo.com";
			var adminPassword = "123456";

			if (!_context.Users.Any(u => u.Email == adminEmail))
			{
				var admin = new Manager { Email = adminEmail };

				await _userManager.CreateAsync(admin, adminPassword);
				await _userManager.AddClaimAsync(admin, new Claim(ClaimTypes.Role, nameof(Role.Admin)));
			}
		}

		private readonly EFMongoDemoDbContext _context;
		private readonly UserManager<Owner> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

	}
}
