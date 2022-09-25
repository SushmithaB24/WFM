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
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);

        }

        #region Models Configuration
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<decimal>().HavePrecision(5, 0);
            configurationBuilder.Properties<string>().HaveColumnType("varchar");
        }
        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Employee
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().Property(x => x.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.Status).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.Manager).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.WfmManager).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.Email).HasMaxLength(30); 
            modelBuilder.Entity<Employee>().Property(x => x.LockStatus).HasMaxLength(30);
            modelBuilder.Entity<Employee>().Property(x => x.Experience);
            modelBuilder.Entity<Employee>().Property(x => x.ProfileId);
            #endregion

            #region Entity: Skill
            modelBuilder.Entity<Skills>().ToTable("Skills");
            modelBuilder.Entity<Skills>().Property(x => x.Name).IsRequired().HasMaxLength(30);
            #endregion

            #region Entity: SkillMap
            modelBuilder.Entity<SkillMap>().ToTable("SkillMaps");
            modelBuilder.Entity<SkillMap>().HasOne(a => a.Employee).WithMany(b => b.SkillMaps).HasForeignKey(c => c.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SkillMap>().HasOne(a => a.Skills).WithMany(b => b.SkillMaps).HasForeignKey(c => c.Skillid).OnDelete(DeleteBehavior.NoAction);
            #endregion
        }
        #endregion
    }
}


