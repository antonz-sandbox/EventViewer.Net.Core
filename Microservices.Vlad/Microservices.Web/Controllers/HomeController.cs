using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsevervices.Web.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microservices.Common;
using System.Text;
using Microsevervices.Web.BusinessLogic;
using Microsoft.Extensions.Options;
using Microservices.Web;

namespace Microsevervices.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeesAggregator _aggregator;
        private readonly MicroservicesUrls _urls;

        public HomeController(ILogger<HomeController> logger, EmployeesAggregator aggregator, IOptions<MicroservicesUrls> options)
        {
            _logger = logger;
            _aggregator = aggregator;
            _urls = options.Value;
        }

        public async Task<IActionResult> IndexAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var employees = await GetEmployeesAsync(httpClient);
                var salaries = await GetSalariesAsync(httpClient, employees);

                var model = new HomeViewModel
                {
                    Employees = _aggregator.GetAccountedEmployees(employees, salaries)
                };

                return View(model);
            }
        }

        private async Task<IEnumerable<SalaryInfo>> GetSalariesAsync(HttpClient httpClient, IEnumerable<Employee> employees)
        {
            JobInformation[] jobs = employees.Select(e => e.JobInfo).ToArray();
            string serializedJobs = JsonConvert.SerializeObject(jobs);
            var content = new StringContent(serializedJobs, Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(_urls.SalaryUrl, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Result = "Success";
                return JsonConvert.DeserializeObject<IEnumerable<SalaryInfo>>(apiResponse);
            }
        }

        private async Task<IEnumerable<Employee>> GetEmployeesAsync(HttpClient httpClient)
        {
            using (var response = await httpClient.GetAsync(_urls.RepoUrl))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Result = "Success";
                return JsonConvert.DeserializeObject<IEnumerable<Employee>>(apiResponse);
            }
        }
    }
}
