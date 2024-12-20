using Demo.DAL.Repository;
using Demo.API.Middlewares;
using Demo.BLL.Mappings;
using Serilog;
using Demo.BLL.Service;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("Logs/Demo_Log.txt", rollingInterval: RollingInterval.Minute).MinimumLevel.Error().CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();

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
