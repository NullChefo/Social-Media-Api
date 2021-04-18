using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SMA.WebApiServices.Authentifications.Services;
using SMA.WebServices.Authentifications.Services;
using System;
using System.Text;

namespace SMA.WebApiServices
{
   
    public class Startup
    {
        // The secret key every token will be signed with.
        // In production, you should store this securely in environment variables
        // or a key management tool. Don't hardcode this into your application!

        //Set Env variable for encrypting the auth token
        static readonly string  SecretKeyForEncription = System.Environment.GetEnvironmentVariable("secretKeyForEncription");
        private static readonly byte[] secretKey = Encoding.ASCII.GetBytes(SecretKeyForEncription);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            var signingKey = new SymmetricSecurityKey(secretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        // Validate the JWT Issuer (iss) claim
                        ValidateIssuer = true,
                        ValidIssuer = "ExampleIssuer",

                        // Validate the JWT Audience (aud) claim
                        ValidateAudience = true,
                        ValidAudience = "ExampleAudience",

                        // Validate the token expiry    
                        ValidateLifetime = true,

                        // If you want to allow a certain amount of clock drift, set that here:
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            ////ILogger - log to local file
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            //loggerFactory.AddFile("C:/Logs/NTS-{Date}.txt");

            // Add JWT generation endpoint:
            var signingKey = new SymmetricSecurityKey(secretKey);
            var options = new TokenProviderOptions
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}