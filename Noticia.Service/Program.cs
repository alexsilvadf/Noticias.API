using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Noticia.Application;
using Noticia.Application.Interface;
using Noticia.Infra;
using Noticia.Service.Extensao;

var builder = WebApplication.CreateBuilder(args);
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.RegistrarServicos();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<NoticiaContext>(x => x.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder =>
        {
            builder.SetIsOriginAllowed((url) =>
            {
                return true;
            })
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();








// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowMyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
