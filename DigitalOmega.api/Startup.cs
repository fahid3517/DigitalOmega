using DigitalOmega.api.Common;
using DigitalOmega.api.DataViewModels.Common;
using DigitalOmega.api.Interface;
using Microsoft.AspNetCore.Builder;
using DigitalOmega.api.Models;
using DigitalOmega.api.Services.Implement;
using DigitalOmega.api.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DigitalOmega.api.DTOs;

namespace DigitalOmega.api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _env = environment;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

          //  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           // services.AddDbContext<BlogDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("BlogDBConnection")));

            services.AddDbContext<D_OContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<do_insightContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // services.AddIdentity<DigitalOmega.api.Models.D_OContext, D_OContext>();
            // services.AddIdentity <ApplicationIdentity,IdentityRole>

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(2, 0);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiDB", Version = "v1" });
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

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:7046", "http://fitcentrapp.stagingdesk.com", "https://fitcentrapp.stagingdesk.com")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync("Some custom error message if required");
                };
            });

            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   var keyByteArray = Encoding.ASCII.GetBytes(this.Configuration.GetValue<String>("Tokens:Key"));
                   var signinKey = new SymmetricSecurityKey(keyByteArray);

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = signinKey,
                       ValidAudience = "Audience",
                       ValidIssuer = "Issuer",
                       ValidateIssuerSigningKey = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.FromMinutes(0)
                   };
               });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:4000", "http://fitcentrapp.stagingdesk.com", "https://fitcentrapp.stagingdesk.com")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
            services.AddScoped<IUserService, UsersService>();
            services.AddSingleton<IUserService, UsersService>();
            services.AddTransient<IUserService, UsersService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddSingleton<IAgentService, AgentService>();
            services.AddTransient<IAgentService, AgentService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddSingleton<IProviderService, ProviderService>();
            services.AddTransient<IProviderService, ProviderService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddSingleton<IPackageService, PackageService>();
            services.AddTransient<IPackageService, PackageService>();
            services.AddScoped<IIPService, IPService>();
            services.AddSingleton<IIPService, IPService>();
            services.AddTransient<IIPService, IPService>();
            services.AddScoped<IDispositonService, DispositonService>();
            services.AddSingleton<IDispositonService, DispositonService>();
            services.AddTransient<IDispositonService, DispositonService>();
            services.AddScoped<IOrderService, OrderSerivce>();
            services.AddSingleton<IOrderService, OrderSerivce>();
            services.AddTransient<IOrderService, OrderSerivce>();
            services.AddScoped<IAffiliateService, AffiliateService>();
            services.AddSingleton<IAffiliateService, AffiliateService>();
            services.AddTransient<IAffiliateService, AffiliateService>();



        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseCors(MyAllowSpecificOrigins);

            //app.UseHttpsRedirection();

            //app.UseExceptionHandler(appBuilder =>
            //{
            //    appBuilder.Use(async (context, next) =>
            //    {
            //        var error = context.Features[typeof(IExceptionHandlerFeature)] as IExceptionHandlerFeature;

            //        if (error != null && error.Error != null)
            //        {
            //            context.Response.StatusCode = 500;
            //            context.Response.ContentType = "application/json";

            //            var path = context.Request.Path.Value;
            //            var controller = path.Split('/')[2];
            //            var action = path.Split('/')[3] ?? "";

            //            var userId = context?.GetRouteData()?.Values["userId"]?.ToString();

            //            MakeLog Err = new MakeLog();
            //            Err.ErrorLog(_env.WebRootPath, "/" + controller + "/" + action + ".txt", "UserId: " + userId + " Error: " + error.Error?.Message ?? "" + "Inner Exception => " + error.Error.InnerException?.Message ?? "");

            //            await context.Response.WriteAsync(JsonConvert.SerializeObject(new Response<bool>
            //            {
            //                IsError = true,
            //                Message = Error.ServerError,
            //                Exception = "UserId: " + userId + " Error: " + error.Error?.Message ?? "" + "Inner Exception => " + error.Error.InnerException?.Message ?? "",
            //                Data = false
            //            }));
            //        }
            //        //when no error, do next.

            //        else await next();
            //    });
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    OnPrepareResponse = ctx =>
            //    {
            //        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            //        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
            //            "Origin, X-Requested-With, Content-Type, Accept");
            //    },

            //});

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Documentation V1");
            //    c.SwaggerEndpoint("/swagger/Admin-v1/swagger.json", "Swagger Admin Documentation V1");
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDB v1"));
            }
            app.UseCors(MyAllowSpecificOrigins);

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
                        "Origin, X-Requested-With, Content-Type, Accept");
                },

            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
