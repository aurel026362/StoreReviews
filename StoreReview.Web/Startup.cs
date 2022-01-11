using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StoreReivew.Infrastracture.Data;
using StoreReivew.Web.Services;
using StoreReview.Core.AutoMapperProfiles;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;
using StoreReview.Core.Services;
using StoreReview.Web.External.Contracts;
using StoreReview.Web.Services;

namespace StoreReview.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);

            var facebookAuthSettings = new FacebookAuthSettings();
            Configuration.Bind(nameof(FacebookAuthSettings), facebookAuthSettings);
            services.AddSingleton(facebookAuthSettings);

            var authOptions = authOptionsConfiguration.Get<AuthOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = authOptions.GetSymetricSecurityKey(), 
                        ValidateIssuerSigningKey = true
                    };
                }).AddFacebook(options =>
                {
                    options.AppId = facebookAuthSettings.AppId;
                    options.AppSecret = facebookAuthSettings.AppSecret;
                });

            services.AddHttpClient();
            services.AddSingleton<IFacebookAuthService, FacebookAuthService>();
            //services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddIdentityCore<User>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddRoles<Role>()
                .AddEntityFrameworkStores<StoreReviewDbContext>();


            services.AddDbContext<StoreReviewDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AppData")));

            services.AddCors(options =>
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                })
            );
            services.AddScoped(typeof(ICurrentUser), typeof(HttpContextCurrentUser));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(GetShopsQuery).Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });


            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreReview API", Version = "v1" });
            });


            services.AddScoped<IFileService>(o => new FileService("/files"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Api v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
