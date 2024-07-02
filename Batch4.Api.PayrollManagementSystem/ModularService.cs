using Batch4.Api.PayrollManagementSystem.BusinessLogic.Services;
using Batch4.Api.PayrollManagementSystem.DataAccess.Services;
using System.Runtime.CompilerServices;

namespace Batch4.Api.PayrollManagementSystem
{
    public static class ModularService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDataAccessServices();
            services.AddBusinessLogicServices();
            return services;
        }

        private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<EmployeeDataAccess>();
            return services;
        }

        private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<EmployeeService>();
            services.AddScoped<PayrollService>();
            return services;
        }
    }
}
