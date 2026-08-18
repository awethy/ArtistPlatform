using ArtistPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtistPlatform.Infrastructure.Persistence.Configurations
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(f => new
            {
                f.UserId,
                f.ArtistId
            });

            builder
                .HasOne(f => f.User)
                .WithMany(u => u.Follows)
                .HasForeignKey(u => u.UserId);
            builder
                .HasOne(f => f.Artist)
                .WithMany(u => u.Followers)
                .HasForeignKey(u => u.ArtistId);
        }
    }
}
