using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Serilog;
using ShopAPI.Configurations;
using ShopAPI.Data;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx,lc)=>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
    


// Add services to the container.
var connString = builder.Configuration.GetConnectionString("StoreDBConn");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddIdentityCore<APIUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<StoreDbContext>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => 
    options.AddPolicy("AllowAll",b=>b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin())
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAll");
app.Run();