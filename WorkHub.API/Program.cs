
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;
using WorkHub.BLL.Mapping;
using WorkHub.BLL.ServiceClass;
using WorkHub.BLL.ServiceInterface;
using WorkHub.DAL.Repository_Classes;
using WorkHub.DAL.Repository_Interfaces;
using ApplicationContext = WorkHub.DAL.Context.ApplicationContext;

namespace WorkHub.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();

            //Configure Serilog
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)// it is preferable to do any additional Configuration like this line in  appsettings.json file
            .WriteTo.Console()
            .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            builder.Host.UseSerilog();


            //Register Database
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr"));
            });
            //Fluent Validation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            ////for Registerint userManger Service
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppContext>();

            ////Configure Authentication + JWT
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //change cookie from default to token
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //return unauthrized response
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(
            //           Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            //    };
            //});

            ////using cors policy to allow clients use my server
            //builder.Services.AddCors(op =>
            //{
            //    op.AddPolicy("allowFlutterApp", op =>
            //    {
            //        op.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //    });
            //});

            //for using AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //Registeration Repositories and Services
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            //Register SignalR
            //builder.Services.AddSignalR();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    //await RoleSeeder.SeedRolesAsync(services);
            //}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

            }
            app.UseSerilogRequestLogging();
            app.UseCors("allowFlutterApp");
            app.UseAuthorization();
            app.MapControllers();
            //app.MapHub<ChatHub>("/chatHub");
            app.Run();
        }
    }
}
