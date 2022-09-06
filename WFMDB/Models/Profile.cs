using System;
using System.Collections.Generic;

namespace WFMDB.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Employees = new HashSet<Employee>();
        }

        public int ProfileId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
