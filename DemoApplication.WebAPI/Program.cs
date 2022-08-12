using DemoApplication.WebAPI.DatabaseContext;
using DemoApplication.WebAPI.DatabaseSeeder;
using DemoApplication.WebAPI.Models;
using DemoApplication.WebAPI.Services;
using DemoApplication.WebAPI.Services.ObjectMapping;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<EmployeeSeeder>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<IEmployeeMappingService, EmployeeMapping>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seed")
    SeedData(app);

void SeedData(IHost app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopeFactory.CreateScope()) { 

        var service = scope.ServiceProvider.GetService<EmployeeSeeder>();

        service.Seed();

    }
};

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
