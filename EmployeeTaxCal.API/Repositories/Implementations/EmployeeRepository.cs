using EmployeeTaxCal.API.Models;
using EmployeeTaxCal.API.Repositories.Interfaces;

namespace EmployeeTaxCal.API.Repositories.Implementations
{
    public class EmployeeRepository: IEmployee
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeRepository(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int CreateEmployee(Employee employee)
        {
            int result = -1;
            if (employee == null)
            {
                result = 0;
            }
            else
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                result = employee.EmployeeId;
            }
            return result;
        }

        public int DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
