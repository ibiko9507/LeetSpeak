using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";
        options.LogoutPath = "/Login/Logout";
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

#region IsLoggedIn

builder.Services.AddHttpClient();
//token

var client = builder.Services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>().CreateClient();

var response = await client.GetAsync("https://localhost:7253/user/IsUserLoggedIn");

if (response.IsSuccessStatusCode)
{
	var result = await response.Content.ReadAsStringAsync();
	var isUserLoggedIn = JsonSerializer.Deserialize<bool>(result);
}

#endregion IsLoggedIn

builder.Services.AddAuthentication("Admin")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Translate/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Translate}/{action=Translation}/{id?}"); //mvc temp data.

app.UseCors("AllowOrigin"); // CORS ayarlarýný etkinleþtirme

app.Run();
