using Management.Infraestructure.DTO;
using Management.Infraestructure.Repositories;
using Management.Infraestructure.Repositories.Interface;
using Management.Services.Employee;
using Management.Services.Employee.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCuttingCofiguration
{
    public class IOC
    {
        public static void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            
        }

    }
}
