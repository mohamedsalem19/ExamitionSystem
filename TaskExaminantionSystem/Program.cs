
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using TaskExaminantionSystem.Config;
using TaskExaminantionSystem.MiddleWare;
using TaskExaminantionSystem.Services;
using TaskExaminantionSystem.ViewModels.InstructorView;

namespace TaskExaminantionSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(InstructorProfiler).Assembly);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                container.RegisterModule(new AutoFacService());
            });
            var app = builder.Build();
            AutoMapperService.Mapper = app.Services.GetService<IMapper>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseMiddleware<GlobalErrorMedlwareHandler>();
            app.Run();
        }
    }
}
