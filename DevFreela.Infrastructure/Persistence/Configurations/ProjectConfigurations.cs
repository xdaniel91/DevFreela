using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations;
public class ProjectConfigurations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("project").HasKey(p => p.Id);

        builder.HasOne(p => p.Freelancer)
            .WithMany(fl => fl.OwnedProjects)
            .HasForeignKey(fk => fk.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Client)
            .WithMany()
            .HasForeignKey(x => x.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
