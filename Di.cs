using ASDP.FinalProject.Behaviors;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Services;
using ASDP.FinalProject.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Refit;
using Scrutor;
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using ASDP.FinalProject.UseCases.Employees.Commands;
using ASDP.FinalProject.Services.TagReplacers;

namespace ASDP.FinalProject
{
    public static class Di
    {
        public static IServiceCollection Inject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdspContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("Default"));
                x.EnableSensitiveDataLogging();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Scan(x => x.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(x => x.AssignableTo(typeof(IRequestValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            services.Scan(x => x.FromExecutingAssembly()
                .AddClasses(x => x.AssignableTo(typeof(IRequestHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(x => x.FromExecutingAssembly()
                .AddClasses(x => x.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            

            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddScoped<ITagsService, TagsService>();

            services.Scan(x => x.FromAssemblies(Assembly.GetExecutingAssembly())
                            .AddClasses(x => x.AssignableTo(typeof(ITagReplacer)))
                            .AsImplementedInterfaces()
                            .AsSelf()
                            .WithScopedLifetime());

            return services;
        }
    }
}
