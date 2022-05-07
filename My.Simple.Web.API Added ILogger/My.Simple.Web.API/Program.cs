using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Simple.Web.API.Controllers;
using My.Simple.Web.API.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
builder.Services.Configure<MailInfo>(Configuration.GetSection("MailInfo"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "SampleCORS", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

builder.Services.AddApiVersioning(option =>
{
    option.DefaultApiVersion = new ApiVersion(1, 0);
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("SampleCORS");
app.UseAuthorization();

app.MapControllers();

app.Run();
