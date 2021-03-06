using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using CurriculumRepository.API.Configuration;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Newtonsoft.Json;
using CurriculumRepository.CORE.Data.Models.Account;
using CurriculumRepository.CORE.Data.Validators.Account;
using CurriculumRepository.API.Services.Scenario;
using CurriculumRepository.API.Services.Activity;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.API.Repositories.KeywordRepository;
using CurriculumRepository.API.Repositories.LearningOutcomeCtRepository;
using CurriculumRepository.API.Repositories.LearningOutcomeSubjectRepository;
using CurriculumRepository.API.Repositories.LsCorrelationRepository;
using CurriculumRepository.Models.Repositories.LsCorrelationRepository;
using CurriculumRepository.API.Repositories.StrategyMethodRepository;
using CurriculumRepository.API.Repositories.LaStrategyMethodRepository;
using CurriculumRepository.API.Repositories.LaTeachingAidRepository;
using CurriculumRepository.API.Repositories.TeachingAidRepository;
using CurriculumRepository.API.Repositories.LsLaRepository;
using CurriculumRepository.API.Repositories.TeachingSubjectRepository;
using CurriculumRepository.API.Repositories.LaCollaborationRepository;
using CurriculumRepository.API.Repositories.LaPerformanceRepository;
using CurriculumRepository.API.Repositories.LaTypeRepository;
using CurriculumRepository.API.Repositories.TeachingAidTypeRepository;
using CurriculumRepository.API.Repositories.StrategyMethodTypeRepository;
using CurriculumRepository.API.Services.SelectData;
using CurriculumRepository.API.Helpers.Sort;
using CurriculumRepository.API.Models.Entities;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using CurriculumRepository.API.Extensions.Exceptions;
using CurriculumRepository.CORE.Entities;
using Microsoft.AspNetCore.Http;

namespace CurriculumRepository
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            CreateSerilogLogger(configuration);
        }

        private void CreateSerilogLogger(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging((builder) =>
            {
                builder.AddSerilog(dispose: true);
            });
            services.AddControllers(options =>
            {
            }).AddFluentValidation()
              .AddNewtonsoftJson(opt => {
                  opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Curriculum Repository API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

            // SPA
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../ClientApp/dist";
            });

            // Auto mapper
            services.AddAutoMapper(typeof(Startup));

            // Database Context
            services.AddDbContext<CurriculumDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CurriculumDatabase")));

            // Validation services
            services.AddTransient<IValidator<AuthenticateUserDTO>, AuthenticateUserDTOValidator>();
            services.AddTransient<IValidator<RegisterUserBM>, RegisterUserBMValidator>();
            services.AddTransient<IValidator<UpdateUserBM>, UpdateUserBMValidator>();

            // Controller services
            services.AddScoped<IScenariosService, ScenariosService>();
            services.AddScoped<IActivitiesService, ActivitiesService>();
            services.AddScoped<ISelectDataService, SelectDataService>();

            // Repositories
            services.AddScoped<IKeywordRepository, KeywordRepository>();
            services.AddScoped<ILearningOutcomeCtRepository, LearningOutcomeCtRepository>();
            services.AddScoped<ILearningOutcomeSubjectRepository, LearningOutcomeSubjectRepository>();
            services.AddScoped<ILsCorrelationInterdisciplinarityRepository, LsCorrelationInterdisciplinarityRepository>();
            services.AddScoped<IStrategyMethodRepository, StrategyMethodRepository>();
            services.AddScoped<ILaStrategyMethodRepository, LaStrategyMethodRepository>();
            services.AddScoped<ILaTeachingAidRepository, LaTeachingAidRepository>();
            services.AddScoped<ITeachingAidRepository, TeachingAidRepository>();
            services.AddScoped<ILsLaRepository, LsLaRepository>();
            services.AddScoped<ITeachingSubjectRepository, TeachingSubjectRepository>();
            services.AddScoped<ILaCollaborationRepository, LaCollaborationRepository>();
            services.AddScoped<ILaPerformanceRepository, LaPerformanceRepository>();
            services.AddScoped<ILaTypeRepository, LaTypeRepository>();
            services.AddScoped<ITeachingAidTypeRepository, TeachingAidTypeRepository>();
            services.AddScoped<IStrategyMethodTypeRepository, StrategyMethodTypeRepository>();
            services.AddScoped<ISort<Ls>, Sort<Ls>>();

            // Identity
            services.AddIdentity<User, UserType>()
                .AddEntityFrameworkStores<CurriculumDatabaseContext>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<UserResolverService>();

            // JWT settings
            var jwtSettings = new JwtSettings();
            Configuration.GetSection("JwtSettings").Bind(jwtSettings);
            services.AddSingleton(jwtSettings);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiddleware(typeof(ExceptionMiddleware));
            }

            app.UseMiddleware(typeof(ExceptionMiddleware));

            app.UseCors("CorsPolicy");

            app.UseSpaStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
                app.UseMiddleware(typeof(ExceptionMiddleware));
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../CurriculumRepository.CLIENT/client-app";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}