using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.interfaces;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApp.Repository;

namespace SchoolWebApp
{
    public class Startup
    {
        private IConfigurationRoot _confString;
        public Startup(IHostingEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Связывание интерфейсов и репозиториев
            services.AddTransient<ITeacher, TeacherRepository>();
            services.AddTransient<IStudent, StudentRepository>();
            services.AddTransient<ILevel, LevelRepository>();
            services.AddTransient<IClass, ClassRepository>();
            services.AddTransient<IClassParallel, ClassParallelRepository>();
            services.AddTransient<IAcademicYear, AcademicYearRepository>();


            services.AddMvc();
            services.AddRazorPages();
            // Добавление контекста БД
            services.AddDbContext<AppDBContent>(options =>
                    options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Error");
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Инициализация объектов БД
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
