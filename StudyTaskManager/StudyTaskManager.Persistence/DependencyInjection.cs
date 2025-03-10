
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace StudyTaskManager.Persistence
{
    /// <summary>
    /// ����� ��� ���������� ��������
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        /// <summary>
        /// ���� ����������� ����� �������
        /// </summary>
        {
            return services;
        }
    }

}
