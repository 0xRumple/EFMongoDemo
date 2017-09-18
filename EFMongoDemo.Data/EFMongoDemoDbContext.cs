using Blueshift.EntityFrameworkCore.MongoDB.Annotations;
using EFMongoDemo.Core.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace EFMongoDemo.Data
{
	[MongoDatabase("carsDb")]
	public class EFMongoDemoDbContext : DbContext
	{
		public EFMongoDemoDbContext(DbContextOptions<EFMongoDemoDbContext> options)
			: base((DbContextOptions) options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = "mongodb://localhost";
			//optionsBuilder.UseMongoDb(connectionString);

			var mongoUrl = new MongoUrl(connectionString);
			//optionsBuilder.UseMongoDb(mongoUrl);

			MongoClientSettings settings = MongoClientSettings.FromUrl(mongoUrl);
			//settings.SslSettings = new SslSettings
			//{
			//    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
			//};
			//optionsBuilder.UseMongoDb(settings);

			MongoClient mongoClient = new MongoClient(settings);
			optionsBuilder.UseMongoDb(mongoClient);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
		}

		public DbSet<Car> Cars { get; set; }
		public DbSet<Owner> Owners { get; set; }
	}
}
