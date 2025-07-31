using Microsoft.OpenApi.Models; //swagger içiçn indirdiðimiz kütüphaneyle otomatik kullanýlabiliyor
using FinalVarlikCf.Data;
using Microsoft.EntityFrameworkCore;
using FinalVarlikCf.Repositories.Interfaces;
using FinalVarlikCf.Repositories.Repositories;
using FinalVarlikCf.Business.Services;
using FinalVarlikCf.Business.Interfaces;
namespace FinalVarlikCf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FinalVarlikCf API",
                    Version = "v1"
                });
            });

            builder.Services.AddScoped<IAssetRepository, AssetRepository>();
            builder.Services.AddScoped<IAssetServices, AssetService>();

            // DbContext’i ekliyoruz
            //Lazy proxies de bu kýsýmda baðlandý
            /* builder.Services.AddDbContext<MyDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseLazyLoadingProxies());*/

            builder.Services.AddScoped<MyDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Swagger JSON dosyasýný üretir

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinalVarlikCf API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
