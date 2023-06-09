using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CS_API2022.Data;
using CS_API2022.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CS_API2022Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS_API2022Context") ?? throw new InvalidOperationException("Connection string 'CS_API2022Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {



    options.AddPolicy(name: "MyPolicy",



        builder =>
        {

            builder.WithOrigins("https://localhost:44328",
       "http://localhost:4200", "*")
                    .WithMethods("POST", "PUT", "DELETE", "GET")

                    .AllowAnyOrigin()

                    .AllowAnyMethod()

                    .AllowAnyHeader();

        });



});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthorizationMiddleware>();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
