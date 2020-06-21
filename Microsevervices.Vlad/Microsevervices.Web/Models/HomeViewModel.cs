using Microsevervices.Web.BusinessLogic;
using System.Collections.Generic;

namespace Microsevervices.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<AccountedEmployee> Employees { get; set; }
    }
}
