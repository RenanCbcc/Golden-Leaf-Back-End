using Golden_Leaf_Back_End.Filters;
using Golden_Leaf_Back_End.Models;
using Golden_Leaf_Back_End.Models.CategoryModels;
using Golden_Leaf_Back_End.Models.ClientModels;
using Golden_Leaf_Back_End.Models.ProductModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Golden_Leaf_Back_End
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;
        private readonly string stringConnection;
        private readonly string stringAudience;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
            if (environment.IsDevelopment())
            {
                stringConnection = configuration["ConnectionStrings:SqlServerConnection"];
                stringAudience = configuration["Jwt:AudienceDevelopment"];
            }
            if (environment.IsProduction())
            {
                stringConnection = configuration["ConnectionStrings:PostgresqlConnection"];
                stringAudience = configuration["Jwt:AudienceProduction"];
            }
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<GoldenLeafContext>(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.UseSqlServer(stringConnection);
                }
                if (environment.IsProduction())
                {
                    options.UseNpgsql(stringConnection);
                }
            });

            //Injection
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            //CORS Policy
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().WithOrigins(stringAudience);
                });
            });

            //Authentication and Autorization
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = stringAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.FromHours(1)
                    };
                }
            );

            services.AddApiVersioning();

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ErrorResponseFilter));
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Golden Leaf", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Golden Leaf v1");
                    options.DefaultModelsExpandDepth(-1);

                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
