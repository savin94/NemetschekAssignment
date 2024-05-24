using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NemetschekAssignment.Core.Services;
using OMS.Infrastructure.Automapper;
using OndoNet.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Automapper
builder.Services.AddAutoMapper(typeof(DefaultAutomapperProfile));

// Register services
builder.Services.AddScoped<IDocumentService, DocumentService>();

// Database
string migrationsAssembly = typeof(NemetschekDbContext).GetTypeInfo().Assembly.GetName().Name;
builder.Services.AddDbContext<NemetschekDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("MainConnection"), sqliteOptions =>
    {
        sqliteOptions.MigrationsAssembly(migrationsAssembly);
    });

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }

    options.ConfigureWarnings(warningsBuilder =>
    {
        // Entity Framework Core 5.0 Warning limiting operator ('Skip'/'Take') without an 'OrderBy' operator
        // Entity Framework generates warning event if we use FirstOrDefault or SingleOrDefault on a primary key selection.
        // This is because, these queries are mapped in T-SQL using - Take(1) statement. So for now we just ignore the warning.
        warningsBuilder.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning);
        warningsBuilder.Ignore(CoreEventId.FirstWithoutOrderByAndFilterWarning);
    });
});

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

app.Run();
