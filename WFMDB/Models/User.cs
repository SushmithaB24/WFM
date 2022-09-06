using System;
using System.Collections.Generic;

namespace WFMDB.Models
{
    public partial class User
    {
        public User()
        {
            EmployeeManagerNavigations = new HashSet<Employee>();
            EmployeeWfmManagerNavigations = new HashSet<Employee>();
            Softlocks = new HashSet<Softlock>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? Email { get; set; }

        public virtual ICollection<Employee> EmployeeManagerNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeWfmManagerNavigations { get; set; }
        public virtual ICollection<Softlock> Softlocks { get; set; }
    }
}
