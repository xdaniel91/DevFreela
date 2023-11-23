using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations;
public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
{
    public void Configure(EntityTypeBuilder<ProjectComment> builder)
    {
        builder.ToTable("project_comment").HasKey(p => p.Id);

        builder.HasOne(pc => pc.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(x => x.IdProjet)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pc => pc.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(x => x.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
