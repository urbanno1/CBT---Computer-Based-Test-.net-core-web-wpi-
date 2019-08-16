using CBT.DataModel.DataModel;
using CBT.Web.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CBT.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Dependency Injection
            services.RegisterServices();
            //Adding the Connection string for the database connection
            services.AddDbContext<CBTDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("CBTEntities")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            AutoMapperConfig.Initialize();

            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<CBTDbContext>()
            .AddDefaultTokenProviders();

            //Adding the JWT Authentication.
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                
            }).AddJwtBearer(options =>
              {
                  var tokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = GetSignInKey(),
                      ValidateIssuer = true,
                      ValidIssuer = GetIssuer(),
                      ValidateAudience = true,
                      ValidAudience = GetAudience(),
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero
                  };
                  options.TokenValidationParameters = tokenValidationParameters;
                  options.RequireHttpsMetadata = false;
              });
            
            
            
            //.AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuerSigningKey = true,
            //        RequireExpirationTime = true,
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero,
            //        ValidAudience = Configuration["jwt:Site"],
            //        ValidIssuer = Configuration["Jwt:Site"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:SigningKey"])),

            //    };
            //});

           
            //Enable CORS in the application.
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseMvc();
        }

        
        static private SymmetricSecurityKey GetSignInKey()
        {
            const string secretKey = "very_long_very_secret_secret";
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            return signingKey;
        }

        static private string GetIssuer()
        {
            return "issuer";
        }

        static private string GetAudience()
        {
            return "audience";
        }


    }
}
