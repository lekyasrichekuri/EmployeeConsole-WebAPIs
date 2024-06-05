using Employee.WebApi.BLL.Interfaces;
using Employee.WebApi.BLL.MappingProfiles;
using Employee.WebApi.BLL.Services;
using Employee.WebApi.DAL.Interfaces;
using Employee.WebApi.DAL.Services;
using EmployeeConsole_WebAPIs.Employee.WebApi.Models.Model;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<ILocationService, LocationService>();
builder.Services.AddSingleton<IRoleService, RoleService>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddSingleton<IStatusService, StatusService>();
builder.Services.AddSingleton<IDbService, DbService>();
builder.Services.AddSingleton<LekyaDbContext>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

//var configuration = app.Services.GetRequiredService<IConfiguration>();

//var connectionString = configuration.GetConnectionString("Database");


//builder.Services.AddSingleton<LekyaEfContext>(provider => new LekyaEfContext(connectionString));

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