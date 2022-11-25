using ArmorFeedApi.Comments.Domain.Repositories;
using ArmorFeedApi.Comments.Domain.Services;
using ArmorFeedApi.Comments.Persistence.Repositories;
using ArmorFeedApi.Comments.Services;
using ArmorFeedApi.Customers.Domain.Models;
using ArmorFeedApi.Customers.Domain.Repositories;
using ArmorFeedApi.Customers.Domain.Services;
using ArmorFeedApi.Customers.Persistence.Repositories;
using ArmorFeedApi.Customers.Services;
using ArmorFeedApi.Enterprises.Domain.Models;
using ArmorFeedApi.Payments.Domain.Repositories;
using ArmorFeedApi.Payments.Domain.Services;
using ArmorFeedApi.Payments.Persistence.Repositories;
using ArmorFeedApi.Payments.Services;
using ArmorFeedApi.Shared.Persistence.Contexts;
using ArmorFeedApi.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ArmorFeedApi.Enterprises.Domain.Repositories;
using ArmorFeedApi.Enterprises.Domain.Services;
using ArmorFeedApi.Enterprises.Persistence.Repositories;
using ArmorFeedApi.Enterprises.Services;
using ArmorFeedApi.Security.Authorization.Handlers.Implementations;
using ArmorFeedApi.Security.Authorization.Handlers.Interfaces;
using ArmorFeedApi.Security.Authorization.Middleware;
using ArmorFeedApi.Security.Authorization.Settings;
using ArmorFeedApi.Shipments.Domain.Repositories;
using ArmorFeedApi.Shipments.Domain.Services;
using ArmorFeedApi.Shipments.Persistence.Repositories;
using ArmorFeedApi.Shipments.Services;
using ArmorFeedApi.Vehicles.Domain.Repositories;
using ArmorFeedApi.Vehicles.Domain.Services;
using ArmorFeedApi.Vehicles.Persistence.Repositories;
using ArmorFeedApi.Vehicles.Services;


using Microsoft.OpenApi.Models;
using IUnitOfWork = ArmorFeedApi.Shared.Domain.Repositories.IUnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Add CORS service
builder.Services.AddCors();

//AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen(options =>
    {
        // Add API Documentation Information
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "ArmorFeed API",
            Description = "ArmorFeed RESTful API",
            
        });
        options.EnableAnnotations();
        options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Description = "JWR Authorization header using Bearer scheme"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id="bearerAuth"}
             },   
            Array.Empty<string>()
            }
        });
    });
// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Database Connection with Sensitive and Detailed Information and Errors enabled
//
// builder.Services.AddDbContext<AppDbContext>(
//     options => options.UseMySQL(connectionString)
//         .LogTo(Console.WriteLine, LogLevel.Information)
//         .EnableSensitiveDataLogging()
//         .EnableDetailedErrors());

// Database Connection with Standard Level for Information and Errors

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null) options.UseMySQL(connectionString);
});

// Add lowercase routes
builder.Services.AddRouting(options => 
    options.LowercaseUrls = true);

// Dependency Injection Configuration ArmorFeed

//Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//ArmorFeed Injection Configuration
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
builder.Services.AddScoped<IEnterpriseService, EnterpriseService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();

// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler<Customer>, JwtHandlerCustomer>();
builder.Services.AddScoped<IJwtHandler<Enterprise>, JwtHandlerEnterprise>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ArmorFeedApi.Shared.Mapping.ModelToResourceProfile),
    typeof(ArmorFeedApi.Shared.Mapping.ResourceToModelProfile),
    typeof(ArmorFeedApi.Customers.Mapping.ModelToResourceProfile),
    typeof(ArmorFeedApi.Customers.Mapping.ResourceToModelProfile),
    typeof(ArmorFeedApi.Enterprises.Mapping.ModelToResourceProfile),
    typeof(ArmorFeedApi.Enterprises.Mapping.ResourceToModelProfile));


var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("v1/swagger.json", "v1");
            options.RoutePrefix = "swagger";
        });
}

//Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//Configure Error Handler Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

//Configure JWT Handling Middleware
app.UseMiddleware<JwtMiddlewareCustomer>();
app.UseMiddleware<JwtMiddlewareEnterprise>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();