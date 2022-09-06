using System;
using System.Collections.Generic;

namespace WFMDB.Models
{
    public partial class Skillmap
    {
        public int? EmployeeId { get; set; }
        public decimal? Skillid { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Skill? Skill { get; set; }
    }
}
