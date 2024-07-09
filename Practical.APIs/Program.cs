using BLL.Interfaces;
using BLL.Repositories;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Practical.APIs
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string text = "MyPolicy";


			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddScoped<IDataRepository, DataRepository>();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddCors(options =>
			{
				options.AddPolicy(text, options =>
				{
					options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
				});
			});
			builder.Services.AddSwaggerGen();
			var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<DBContext>(options =>
			 {
				 options.UseSqlServer(ConnectionString);
			 });

			var app = builder.Build();
			
			app.UseRouting();
			app.UseCors(text);
				app.MapControllers();
				
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				

				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			

			app.Run();
		}
	}
}