using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee {
                    Id = 1,
                    Name = "Varun",
                    Department = "IT",
                    Email = "varun@gmail.com"
                },


                new Employee
                {
                    Id = 2,
                    Name = "Simmmi",
                    Department = "IT",
                    Email = "Simmi@gmail.com"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Vansh",
                    Department = "IT",
                    Email = "vansh@gmail.com"
                }
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
          return  _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
