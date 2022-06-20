﻿
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.Services_Implementations;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddScoped<IRepository<BasicMean>, BasicMeanRepository>();
        services.AddScoped<IClassroomRepository, ClassroomRepository>();
        services.AddScoped<IService<Classroom>, ClassroomService>();
        services.AddScoped<IObjectContext, SchoolContext>();
        // services.AddScoped<IRepository<Course>, CourseRepository>();
        // services.AddScoped<IRepository<CourseGroup>, CourseGroupRepository>();
        // services.AddScoped<IRepository<Expense>, ExpenseRepository>();
        // services.AddScoped<IRepository<Expense>, ExpenseRepository>();
        // services.AddScoped<IRepository<Position>, PositionRepository>();
        // services.AddScoped<IRepository<Resource>, ResourceRepository>();
        // services.AddScoped<IRepository<Student>, StudentRepository>();
        // services.AddScoped<IRepository<Teacher>, TeacherRepository>();
        // services.AddScoped<IRepository<Tuitor>, TuitorRepository>();
        // services.AddScoped<IRepository<Worker>, WorkerRepository>();
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddDbContext<SchoolContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("SchoolContextSQLite")));
        
        // services.AddDatabaseDeveloperPageExceptionFilter();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
        
            var context = services.GetRequiredService<SchoolContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    } 
}