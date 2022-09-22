namespace RestAPI.Models
{
    public class SkillMap
    {
        public int? EmployeeId { get; set; }
        public decimal? Skillid { get; set; }
        public  Employee Employees { get; set; }
        public  Skills Skills { get; set; }
    }
}
