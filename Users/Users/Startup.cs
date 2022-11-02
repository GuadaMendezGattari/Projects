using System;
using Microsoft.OpenApi.Models;
using Users.Data;
using Microsoft.EntityFrameworkCore;

namespace Users
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users", Version = "v1" }));

            string connection = Configuration.GetConnectionString("UsersConnection");
            services.AddDbContext<UsersDbContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Users v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(ends => ends.MapControllers());
        }
    }
}

