using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class Skills
    {
        [Key]
        public decimal Skillid { get; set; }
        public string Name { get; set; }
        public ICollection<SkillMap> SkillMaps { get; set; }
    }
}
