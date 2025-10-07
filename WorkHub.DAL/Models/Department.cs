using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHub.DAL.Models
{
    public class Department
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? ManagerName { get; set; }
        //Navigaton porperty
        public List<Employee>? Employees { get; set; }

    }
}
