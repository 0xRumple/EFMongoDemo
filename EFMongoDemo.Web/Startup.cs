using Blueshift.Identity.MongoDB;
using EFMongoDemo.Core.Models;
using EFMongoDemo.Data;
using EFMongoDemo.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFMongoDemo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        var connectionString = Configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<EFMongoDemoDbContext>(options => options.UseMongoDb(connectionString));

	        services
		        .AddMvc(options => options.ModelBinderProviders.Insert(0, new ObjectIdBinderProvider()))
		        .AddJsonOptions(options => options.SerializerSettings.Converters.Add(new ObjectIdJsonConverter()));

	        services.AddIdentity<Owner, MongoDbIdentityRole>(
				options =>
				{
					options.User.RequireUniqueEmail = true;
					options.Password.RequireDigit = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequiredLength = 6;
				}
				).AddEntityFrameworkMongoDbStores<EFMongoDemoDbContext>();

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

	        //services.AddTransient<EFMongoDemoSeedDate>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

	        //seeder.ClearDatabase().Wait();
	        //seeder.EnsureSeedData().Wait();
		}
    }
}
