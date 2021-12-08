using eBibliotekaCloud.Data;
using eBibliotekaCloud.Repositories;
using eBibliotekaCloud.Services;
using eBibliotekaCloud.Services.Implementation;
using Email;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace eBibliotekaCloud
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        private IHostEnvironment CurrentEnvironment { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eBibliotekaCloud", Version = "v1" });
            });

            //add fluent email DI
            var from = Configuration.GetSection("Email")["From"];
            var gmailSender = Configuration.GetSection("Gmail")["Sender"];
            var gmailPassword = Configuration.GetSection("Gmail")["Password"];
            var gmailPort = Convert.ToInt32(Configuration.GetSection("Gmail")["Port"]);

            services.AddFluentEmail(gmailSender, from)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient("smtp.gmail.com")
                {
                    UseDefaultCredentials = false,
                    Port = gmailPort,
                    Credentials = new NetworkCredential(gmailSender, gmailPassword),
                    EnableSsl = true
                });

            //dodavanje firebase autentikacije
            if (CurrentEnvironment.IsDevelopment())
            {
                services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/ebibliotekadev";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/ebibliotekadev",
                        ValidateLifetime = true,
                        ValidateAudience=false
                    };
                });
            }
            else
            {
                services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/ebilioteka-production";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/ebilioteka-production",
                        ValidateLifetime = true,
                        ValidateAudience = false
                    };
                });
            }
            //dodavanje firebase admin tajni-secrets
            if (CurrentEnvironment.IsDevelopment())
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile($"{Directory.GetCurrentDirectory()}/utils/secrets.json"),
                });
            }
            else
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile($"{Directory.GetCurrentDirectory()}/utils/production-secrets.json"),
                });
            }

            services.AddDbContext<BibliotekaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BibliotekaConnection"));
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            

            //interni servisi

            //repozitoriji
            services.AddScoped<IBookRepo, BookRepo>();

            //servisi
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IZaposlenikService, ZaposlenikService>();
            services.AddScoped<IIzdavacService, IzdavacService>();
            services.AddScoped<IZaduzbaService, ZaduzbaService>();
            services.AddScoped<IKarticaService, KarticaService>();
            services.AddScoped<IKnjigaNarudzbaService, KnjigaNarudzbaService>();
            services.AddScoped<IMailSender, MailSender>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eBibliotekaCloud v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
                opt.AllowAnyOrigin();
            });

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
