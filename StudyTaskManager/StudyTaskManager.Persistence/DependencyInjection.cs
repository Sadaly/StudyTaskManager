using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace StudyTaskManager.Persistence
{
    /// <summary>
    /// ����� ��� ���������� ��������
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// ����������� ��� ���������� ��������
        /// </summary>
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            return services;
        }
    }

}
