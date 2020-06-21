using System.Collections.Generic;
using Microservices.Common;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Repo.Controllers
{
    public class PeopleController : ControllerBase
    {
        private readonly RandomPseudoRepository _repository;

        public PeopleController(RandomPseudoRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Employees(int count)
        {
            IEnumerable<Employee> employees = _repository.GetRandomEmployees(count);
            return new JsonResult(employees);
        }
    }
}