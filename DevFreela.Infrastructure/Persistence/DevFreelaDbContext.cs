using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;
public class DevFreelaDbContext : DbContext
{
    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
    {

    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<ProjectComment> Comments { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Project>().ToTable("project").HasKey(p => p.Id);

        builder.Entity<Project>()
            .HasOne(p => p.Freelancer)
            .WithMany(fl => fl.OwnedProjects)
            .HasForeignKey(fk => fk.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<User>().ToTable("user").HasKey(p => p.Id);

        builder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(x => x.IdSkill).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Skill>().ToTable("skill").HasKey(p => p.Id);

        builder.Entity<ProjectComment>().ToTable("project_comment").HasKey(p => p.Id);

        builder.Entity<ProjectComment>()
            .HasOne(pc => pc.Project)
            .WithMany(p => p.Comments).HasForeignKey(x => x.IdProjet)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ProjectComment>()
            .HasOne(pc => pc.User)
            .WithMany(p => p.Comments).HasForeignKey(x => x.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<UserSkill>().ToTable("user_skill").HasKey(p => p.Id);
        builder.Entity<UserSkill>().HasOne(ps => ps.User).WithMany(u => u.Skills).HasForeignKey(x => x.IdUser);
    }
}
