using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebMessager.Models
{
    public class MessagerContext : DbContext
    {
        public MessagerContext(DbContextOptions<MessagerContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<PrivateMessage> PrivateMessage { get; set; }
        public DbSet<GroupMessage> GroupMessage { get; set; }
        public DbSet<GroupChat> GroupChat { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FriendConfiguration1());
            modelBuilder.ApplyConfiguration(new PrivateMessageConfiguration1());

        }
    }
    public class FriendConfiguration1 : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable(nameof(Friend)).HasKey(f => f.Id);
            builder.HasOne(f => f.User1)
                    .WithMany()
                    .HasForeignKey(f => f.User1Id)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(f => f.User2)
                    .WithMany()
                    .HasForeignKey(f => f.User2Id)
                    .OnDelete(DeleteBehavior.NoAction);

            

        }

    }
    public class PrivateMessageConfiguration1 : IEntityTypeConfiguration<PrivateMessage>
    {
        public void Configure(EntityTypeBuilder<PrivateMessage> builder)
        {
            builder.ToTable(nameof(PrivateMessage)).HasKey(f => f.Id);
            builder.HasOne(f => f.UserFrom)
                    .WithMany()
                    .HasForeignKey(f => f.UserFromId)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(f => f.UserTo)
                    .WithMany()
                    .HasForeignKey(f => f.UserToId)
                    .OnDelete(DeleteBehavior.NoAction);



        }

    }

}
