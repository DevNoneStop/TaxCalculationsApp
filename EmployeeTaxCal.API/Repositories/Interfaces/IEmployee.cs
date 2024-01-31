using EmployeeTaxCal.API.Models;

namespace EmployeeTaxCal.API.Repositories.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetById(int id);
        int CreateEmployee(Employee employee);

        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int id);
    }
}
