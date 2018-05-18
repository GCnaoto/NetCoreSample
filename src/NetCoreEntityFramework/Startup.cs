using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using NetCoreEntityFramework.Model;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;

namespace NetCoreEntityFramework
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			// Add framework services.
			services.AddMvc();
            services.AddEntityFrameworkSqlServer().AddDbContext<LogDbContext>();
            services.AddDbContext<WorkDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefoltDb")));
            services.AddScoped<ICRUDRepository, CRUDRepository>();

            // SwaggerGenサービスの登録
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("orders", new Info { Title = "Order APIs", Version = "v1" });
            });
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        { 

            // Swaggerミドルウェアの登録
            app.UseSwagger();
            // SwaggerUIミドルウェアの登録
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/orders/swagger.json", "Order APIs sandbox.");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            loggerFactory.AddNLog();
            DbInitailizer.InitializeDatabase(app);
            LogManager.Configuration.Variables["ConnectionStrings"] = Configuration.GetConnectionString("NLogDb");
            
            app.UseMvc();
		}	
    }
}
