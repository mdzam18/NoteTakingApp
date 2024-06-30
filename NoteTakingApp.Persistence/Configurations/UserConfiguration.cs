using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NoteTakingApp.Domain.User;

namespace NoteTakingApp.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Username).IsUnique();

            builder.Property(x => x.Username).IsUnicode(false).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Password).IsUnicode(false).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.Notes).WithOne(t => t.User).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
