using ASDP.FinalProject.Behaviors;
using ASDP.FinalProject.Services;
using ASDP.FinalProject.Validators;
using MediatR;
using Refit;
using Scrutor;
using System.Reflection;

namespace ASDP.FinalProject
{
    public static class Di
    {
        public static IServiceCollection Inject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            //services.Scan(x => x.FromExecutingAssembly().AddClasses().AsImplementedInterfaces());
            services.AddMediatR(x=> x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.Scan(x => x.FromExecutingAssembly()
                .AddClasses(x => x.AssignableTo(typeof(IRequestValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddRefitClient<SigexApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://sigex.kz"));

            return services;
        }
    }
}
