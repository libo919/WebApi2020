using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;
using WebApi2020.DB;
using WebApi2020.Models.AuthModels;

namespace WebApi2020
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication("MyJwt")
                .AddJwtBearer("MyJwt", config =>
                {
                    var issuer = Configuration["JwtSettings:Issuer"];
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Secret"]));
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = issuer,
                        IssuerSigningKey = key,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                    };
                });

            services.AddDbContext<MyContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("XJHDB")), ServiceLifetime.Scoped);
            //services.AddDbContext<ModelContext>(options =>                    options.UseSqlServer(Configuration.GetConnectionString("XJHDB")), ServiceLifetime.Scoped);
            //services.AddDbContext<SqlContext>(options =>                    options.UseSqlServer(Configuration.GetConnectionString("XJHDB")), ServiceLifetime.Scoped);
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<List<ApiUser>>(Configuration.GetSection("APIUsers"));
        }

        /// <summary>
        /// 
        /// </summary>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
