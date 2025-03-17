using FluentValidation;
using Gatherly.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace StudyTaskManager.Application
{
    /// <summary>
    /// ����� ��� ���������� ��������
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// ����������� ��� ���������� ��������
        /// </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration => 
                configuration.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            return services;
        }
    }

}
