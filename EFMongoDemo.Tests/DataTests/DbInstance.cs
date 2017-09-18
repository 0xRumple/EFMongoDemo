using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFMongoDemo.Tests.DataTests
{
	public class DbInstance<T> where T : DbContext
	{
		public DbInstance(Func<DbContextOptions<T>, T> factory)
		{
			var provider = new ServiceCollection()
				.AddEntityFrameworkInMemoryDatabase()
				.BuildServiceProvider();

			var builder = new DbContextOptionsBuilder<T>();
			builder.UseInMemoryDatabase(Guid.NewGuid().ToString())
					.UseInternalServiceProvider(provider);

			_options = builder.Options;
			_factory = factory;
		}

		public T NewContext()
		{
			return _factory(_options);
		}

		private readonly DbContextOptions<T> _options;
		private readonly Func<DbContextOptions<T>, T> _factory;
	}
}
