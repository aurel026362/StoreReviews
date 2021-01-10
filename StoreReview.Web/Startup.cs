using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreReivew.Infrastracture.Data;
using StoreReview.Core.AutoMapperProfiles;
using StoreReview.Core.Interfaces;
using StoreReview.Core.Queries;

namespace StoreReview.Web
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
            services.AddHttpContextAccessor();
            //services.AddScoped(typeof(ICurrentUser), typeof(HttpContextCurrentUser));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(typeof(GetShopsQuery).Assembly); 
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<StoreReviewDbContext>(
                options => options.UseSqlServer(@"Data Source=DESKTOP-999TVV1\SQLEXPRESSBLOODY;Initial Catalog=StoreReview;Integrated Security=True"));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllers();


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "ProjectPlan API", Version = "v1" });
            //    c.OperationFilter<AuthenticationHeaderFilter>();
            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    c.IncludeXmlComments(xmlPath);
            //});
            //services.AddScoped<IFileService>(o => new FileService(FilesPhysicalRootPath, FilesRelativePath, FilesVirtualPath));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
