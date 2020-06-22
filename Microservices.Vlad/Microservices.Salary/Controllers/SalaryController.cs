using Microservices.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microservices.Salary.Controllers
{
    public class SalaryController : ControllerBase
    {
        private readonly SalaryCalculator _calculator;

        public SalaryController(SalaryCalculator calculator)
        {
            _calculator = calculator;
        }
        
        [HttpPost]
        public IActionResult Calculate([FromBody] IEnumerable<JobInformation> employees)
        {
            IEnumerable<SalaryInfo> salaryInfos = _calculator.CalculateSalary(employees);
            return new JsonResult(salaryInfos);
        }
    }
}
