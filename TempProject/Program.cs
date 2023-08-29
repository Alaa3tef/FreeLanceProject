
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TempProject.Hubs;
using TempProject.Models;
using TempProject.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace TempProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			
			builder.Services.AddSignalR();

			// Add services to the container.
			builder.Services.AddCors(option => option.AddPolicy("my", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IRepository<Accident>, Repository<Accident>>();
            //builder.Services.AddScoped<IRepository<Crew>, Repository<Crew>>();
            builder.Services.AddScoped<IRepository<LeadershipVisit>, Repository<LeadershipVisit>>();
            builder.Services.AddScoped<IRepository<NonRecordableAccident>, Repository<NonRecordableAccident>>();
            builder.Services.AddScoped<IRepository<RecordableAccident>, Repository<RecordableAccident>>();
            //builder.Services.AddScoped<IRepository<Drill>, Repository<Drill>>();
			builder.Services.AddScoped<IRepository<StopCardRegister>, Repository<StopCardRegister>>();
			builder.Services.AddScoped<IRepository<Rig>, Repository<Rig>>();
			builder.Services.AddScoped<IRepository<Classification>, Repository<Classification>>();
			builder.Services.AddScoped<IRepository<ClassificationOfAccident>, Repository<ClassificationOfAccident>>();
			builder.Services.AddScoped<IRepository<PreventionCategory>, Repository<PreventionCategory>>();
			builder.Services.AddScoped<IRepository<AccidentCauses>, Repository<AccidentCauses>>();
			builder.Services.AddScoped<IRepository<TypeOfInjury>, Repository<TypeOfInjury>>();
			builder.Services.AddScoped<IRepository<ViolationCategory>, Repository<ViolationCategory>>();
			builder.Services.AddScoped<IRepository<ToolPusherPosition>, Repository<ToolPusherPosition>>();
			builder.Services.AddScoped<IRepository<ToolPusherPositionName>, Repository<ToolPusherPositionName>>();
			builder.Services.AddScoped<IRepository<QHSEPosition>, Repository<QHSEPosition>>();
			builder.Services.AddScoped<IRepository<QHSEPositionName>, Repository<QHSEPositionName>>();
			builder.Services.AddScoped<IRepository<ReportedByPosition>, Repository<ReportedByPosition>>();
			builder.Services.AddScoped<IRepository<ReportedByName>, Repository<ReportedByName>>();
            builder.Services.AddScoped<IRepository<TypeOfObservationCategory>, Repository<TypeOfObservationCategory>>();
            builder.Services.AddScoped<IRepository<JMP>, Repository<JMP>>();
            builder.Services.AddScoped<IRepository<RouteName>, Repository<RouteName>>();
            builder.Services.AddScoped<IRepository<Driver>, Repository<Driver>>();
            builder.Services.AddScoped<IRepository<ComminucationMethod>, Repository<ComminucationMethod>>();
            builder.Services.AddScoped<IRepository<Vehicle>, Repository<Vehicle>>();
            builder.Services.AddScoped<IRepository<Passenger>, Repository<Passenger>>();
			builder.Services.AddScoped<IRepository<JMP_Passenger>, Repository<JMP_Passenger>>();
			builder.Services.AddScoped<IRepository<PTSM>, Repository<PTSM>>();
			builder.Services.AddScoped<IRepository<Attendance>, Repository<Attendance>>();
			builder.Services.AddScoped<IAccidentRepository, AccidentRepository>();
			builder.Services.AddScoped<IStopCardRepository, StopCardRepository>();
			builder.Services.AddScoped<IPTSMRepository, PTSMRepository>();
			builder.Services.AddScoped<IJMPRepository, JMPRepository>();
			builder.Services.AddScoped<IRepository<RigMovePerformance>, Repository<RigMovePerformance>>();
            builder.Services.AddScoped<IRepository<ProblemFacedDuringRigMove>, Repository<ProblemFacedDuringRigMove>>();
            builder.Services.AddScoped<IRigMovePerformanceRepository, RigMovePerformanceRepository>();

            builder.Services.AddScoped<IBOPRepossitory,BOPRepository>();

            builder.Services.AddScoped<IRepository<BOP> , Repository<BOP>>();

            builder.Services.AddDbContext<Context>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
            );

			builder.Services.AddControllersWithViews()
	.AddNewtonsoftJson(options =>
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
			builder.Services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<Context>();
			builder.Services.AddAuthentication(options =>
			{
				//jwt
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;//not valid account
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					//parmeter
					ValidateIssuer = true,
					ValidIssuer = builder.Configuration["JWT:ValidIss"],
					ValidateAudience = true,
					ValidAudience = builder.Configuration["JWT:ValidAud"],
					IssuerSigningKey =
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecrytKey"]))//asdZXCZX!#!@342352
				};
			}); //how to check if toke valid or not;
			builder.Services.AddSwaggerGen(swagger =>
			{
				//This is to generate the Default UI of Swagger Documentation    
				swagger.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "ASP.NET 5 Web API",
					Description = " ITI Projrcy"
				});
				// To Enable authorization using Swagger (JWT)    
				swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
				});
				swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
new string[] { }

					}
				});
			});

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();    
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
			app.UseAuthorization();
            app.UseCors("my");



			app.MapHub<NotificationHub>("/NotificationHub");
			app.MapHub<ArrivalNotificationHub>("/ArrivalNotificationHub");

			app.MapHub<TestHub>("/TestHub");

			app.MapControllers();

            app.Run();
        }
    }
}