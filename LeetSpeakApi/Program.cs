using Google.Protobuf.WellKnownTypes;
using LeetSpeak.DataAccess.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;
using LeetSpeak.Api;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

Host.CreateDefaultBuilder(args)
			   .ConfigureWebHostDefaults(webBuilder =>
			   {
				   // CORS ayarlarý
				   webBuilder.ConfigureKestrel(options =>
				   {
					   options.AddServerHeader = false;
					   options.ListenLocalhost(7253); // veya kullanmak istediðiniz port numarasý
				   }).UseUrls("https://localhost:7253"); // veya kullanmak istediðiniz URL
			   });

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowOrigin", builder =>
	{
		builder
			   .AllowAnyMethod()
			   .AllowAnyHeader()
			   .AllowAnyOrigin();
	});
});

builder.Services.RegisterServices(configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<LeetSpeakDbContext>(config =>
{
    config.UseMySql(configuration.GetConnectionString("MySqlConnection"), new MySqlServerVersion(new Version(8, 0, 32)));
    config.EnableSensitiveDataLogging();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin"); // CORS ayarlarýný etkinleþtirme

app.Run();
