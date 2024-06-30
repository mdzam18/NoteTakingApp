using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteTakingApp.Domain.Note;

namespace NoteTakingApp.Persistence.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired();

            builder.Property(x => x.Description).IsRequired();

            builder.HasOne(x => x.User)
                               .WithMany(x => x.Notes)
                               .HasForeignKey(x => x.UserId)
                               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreatedAt).HasColumnType("datetime").IsRequired();

            builder.Property(x => x.UpdatedAt).HasColumnType("datetime").IsRequired();

            builder.Property(x => x.IsPrivate).IsRequired();
        }
    }
}
