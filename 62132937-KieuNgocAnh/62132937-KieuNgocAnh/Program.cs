using _62132937_KieuNgocAnh.Aplicaion.Products;
using _62132937_KieuNgocAnh.Aplicaion.Users;
using _62132937_KieuNgocAnh.Applicaion.Carts;
using _62132937_KieuNgocAnh.Applicaion.Categorys;
using _62132937_KieuNgocAnh.Applicaion.OrderDetails;
using _62132937_KieuNgocAnh.Applicaion.Orders;
using _62132937_KieuNgocAnh.Applicaion.Roles;
using _62132937_KieuNgocAnh.Models;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TradingContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<ICartService, CartService>();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
        opt => {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
);

builder.Services.AddCors(p => p.AddPolicy("MyCors", builder =>
{
    builder.WithOrigins("http://localhost:3000", "http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}


app.UseCors(policy =>
           policy
           .AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
           );

app.UseHttpsRedirection();

app.UseCors("MyCors");


app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
    {
        await context.Response.WriteAsync("Token Validation Has Failed. Request Access Denied");
    }
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/Images"
}); app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
