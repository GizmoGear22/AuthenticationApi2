using AuthenticationLayer;
using DataLayer.DataAccessHandlers;
using DataLayer.DatabaseAccess;
using FluentValidation;
using FluentValidation.AspNetCore;
using LogicLayer.ApiLogic;
using LogicLayer.DbLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models;
using ValidationLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext
builder.Services.AddDbContext<DBAccess>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DbCnnString")); });


//DI
builder.Services.AddTransient<IDataAccessHandler, DataAccessHandler>();
builder.Services.AddTransient<IRepoAccessLogic, RepoAccessLogic>();
builder.Services.AddTransient<IApiAccessLogic, ApiAccessLogic>();
//Logging
builder.Services.AddLogging(options => options.AddConsole());

//FluentValidation Middleware
builder.Services.AddValidatorsFromAssemblyContaining<NewUserValidation>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-Api-Key",
        Type = SecuritySchemeType.ApiKey,
        Description = "Input Api Key Here"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
}

);

//CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder => builder.AllowCredentials().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiAuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
