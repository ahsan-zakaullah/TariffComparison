using Microsoft.OpenApi.Models;
using TariffComparison.Api.Middlewares;
using TariffComparison.Repository;
using TariffComparison.Services.IServices;
using TariffComparison.Services.Services;

namespace TariffComparison.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(); services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<SearchFilters.SearchFilters>(); // Inject the applicant filter to assign the default values of specific model
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products", Version = "v1" });
            });
            // 1. Register the created repositories
            RegisterRepositories(services);
            // 2. Register the created services
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add the middleware the handle the exception at global level
            app.ConfigureExceptionHandler();

            app.UseRouting();
            
            //Invoking the cors middleware
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products v1"));
        }
    }
}
