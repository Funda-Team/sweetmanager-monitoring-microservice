using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;
using MonitoringService.Application.Internal.CommandServices;
using MonitoringService.Application.Internal.QueryServices;
using MonitoringService.Domain.Repositories;
using MonitoringService.Domain.Services.Booking;
using MonitoringService.Domain.Services.Room;
using MonitoringService.Domain.Services.TypeRoom;
using MonitoringService.Infrastructure.Persistence.EFC.Repositories;
using MonitoringService.Shared.Domain.Repositories;
using MonitoringService.Shared.Infrastructure.Interfaces.ASP.Configuration;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Configuration;
using MonitoringService.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database Configuration
// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("MonitoringContext");

builder.Services.AddTransient<IDbConnection>(db => new MySqlConnection(connectionString));

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<MonitoringContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

#endregion

#region Dependency Injection

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();
builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IRoomCommandService, RoomCommandService>();
builder.Services.AddScoped<IRoomQueryService, RoomQueryService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddScoped<ITypeRoomCommandService, TypeRoomCommandService>();
builder.Services.AddScoped<ITypeRoomQueryService, TypeRoomQueryService>();
builder.Services.AddScoped<ITypeRoomRepository, TypeRoomRepository>();

#endregion 

var app = builder.Build();

#region Ensure Database Created (COMPILE AppDbContext)

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MonitoringContext>();
    context.Database.EnsureCreated();
}

#endregion

app.UseCors(
    b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();