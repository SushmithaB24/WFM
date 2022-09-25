using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class Skills
    {
        [Key]
        public int Skillid { get; set; }
        public string Name { get; set; }
        public ICollection<SkillMap> SkillMaps { get; set; }
    }
}
