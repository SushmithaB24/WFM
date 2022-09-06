using System;
using System.Collections.Generic;

namespace WFMDB.Models
{
    public partial class Softlock
    {
        public int? EmployeeId { get; set; }
        public string? Manager { get; set; }
        public DateTime? Reqdate { get; set; }
        public string? Status { get; set; }
        public DateTime? Lastupdated { get; set; }
        public int Lockid { get; set; }
        public string? Requestmessage { get; set; }
        public string? Wfmremark { get; set; }
        public string? Managerstatus { get; set; }
        public string? Mgrstatuscomment { get; set; }
        public DateTime? Mgrlastupdate { get; set; }

        public virtual User? ManagerNavigation { get; set; }
    }
}
