using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class SkillMap
    {
        [Key]
        public int ID { get; set; }
        public int? EmployeeId { get; set; }
        public int? Skillid { get; set; }
        public  Employee Employee { get; set; }
        public  Skills Skills { get; set; }
    }
}
