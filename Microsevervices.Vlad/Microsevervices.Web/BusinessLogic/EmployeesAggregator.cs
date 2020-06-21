using Microservices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsevervices.Web.BusinessLogic
{
    public class EmployeesAggregator
    {
        public IEnumerable<AccountedEmployee> GetAccountedEmployees(IEnumerable<Employee> employees, IEnumerable<SalaryInfo> salaries)
        {
            return employees.Select(emp => 
            {
                var salaryInfo = salaries.Single(s => s.EmployeeId == emp.JobInfo.EmployeeId);
                return new AccountedEmployee
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    JobInfo = emp.JobInfo,
                    Salary = salaryInfo.Salary
                };
            }
            ).ToArray();
        }
    }
}
