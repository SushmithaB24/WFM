using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? Manager { get; set; }
        public string? WfmManager { get; set; }
        public string? Email { get; set; }
        public string? Lockstatus { get; set; }
        public decimal? Experience { get; set; }
        public int? ProfileId { get; set; }
       
        public ICollection<SkillMap> SkillMaps { get; set; }

       

    }
}
