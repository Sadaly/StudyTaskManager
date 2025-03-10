using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace StudyTaskManager.Infrustracture
{
    /// <summary>
    /// ����� ��� ���������� ��������
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// ����������� ��� ���������� ��������
        /// </summary>
        public static IServiceCollection AddInfrustracture(this IServiceCollection services)
        { 
            return services;
        }
    }
}
