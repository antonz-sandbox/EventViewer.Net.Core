using System;

namespace Microservices.Common
{
    public class Employee
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }        

        public JobInformation JobInfo { get; set; }
    }
}
