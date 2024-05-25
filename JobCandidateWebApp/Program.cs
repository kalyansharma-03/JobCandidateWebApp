using JobCandidate.Infrastructure;
using JobCandidate.Application;
using JobCandidate.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using JobCandidate.Application.Helper;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeSpanNullableConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use default naming policy
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Other Swagger configuration...

    options.MapType<TimeSpan?>(() => new OpenApiSchema { Type = "string", Format = "hh:mm:ss", Nullable = true });
    options.SchemaFilter<TimeSpanNullableSchemaFilter>();
});
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationService(builder.Configuration);

var app = builder.Build();

JobDBMigration.UpdateDatabase(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
