using Microservices.Common;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Repo
{
    public class RandomPseudoRepository
    {
        public IEnumerable<Employee> GetRandomEmployees(int count)
        {
            var random = new Random(Environment.TickCount);
            var nameGenerator = new PersonNameGenerator(random);
            var positions = Enum.GetValues(typeof(Position));

            var employees = Enumerable
                .Range(0, count)
                .Select(i =>
                    new Employee
                    {
                        FirstName = nameGenerator.GenerateRandomFirstName(),
                        LastName = nameGenerator.GenerateRandomLastName(),
                        JobInfo = new JobInformation
                        {
                            EmployeeId = i,
                            Position = (Position)random.Next(positions.Length),
                            ExperienceYears = random.Next(40)
                        }
                    }
                 ).ToList();

            return employees;
        }
    }
}
