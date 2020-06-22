using Microservices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Salary
{
    public class SalaryCalculator
    {
        private readonly Dictionary<Position, int> _baseWageMap = new Dictionary<Position, int>()
        {
            { Position.Accountant, 1500 },
            { Position.ConstructionWorker, 1300 },
            { Position.Driver, 1400 },
            { Position.Manager, 2000 },
            { Position.Policeman, 1700 },
            { Position.Teacher, 1000 },
        };

        private readonly Dictionary<Position, int> _experienceCoefficientMap = new Dictionary<Position, int>()
        {
            { Position.Accountant, 15 },
            { Position.ConstructionWorker, 13 },
            { Position.Driver, 14 },
            { Position.Manager, 20 },
            { Position.Policeman, 17 },
            { Position.Teacher, 10 },
        };

        internal IEnumerable<SalaryInfo> CalculateSalary(IEnumerable<JobInformation> employees)
        {
            return employees.Select(emp => new SalaryInfo
            {
                EmployeeId = emp.EmployeeId,
                Salary = _baseWageMap[emp.Position] + (_experienceCoefficientMap[emp.Position] * emp.ExperienceYears)
            }).ToArray();
        }
    }
}
