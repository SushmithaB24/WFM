using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public class RestAPIDBContext:DbContext
    {
        #region Constructor        
        public RestAPIDBContext(DbContextOptions options) : base(options)       
        {        
        }
        #endregion

        public virtual DbSet<SkillMap> SkillMaps { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public DbSet<EmployeeModel> EmployeeModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);



        }

        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillMap>().HasKey(sc => new { sc.EmployeeId, sc.Skillid });

            modelBuilder.Entity<SkillMap>()
                .HasOne<Employee>(sc => sc.Employees)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.EmployeeId);


            modelBuilder.Entity<SkillMap>()
                .HasOne<Skills>(sc => sc.Skills)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.Skillid);

        }
    }
}


