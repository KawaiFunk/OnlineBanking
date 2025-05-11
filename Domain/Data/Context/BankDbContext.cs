using Domain.Entites;
using System.Data.Entity;

namespace Domain.Data.Context
{
    public class BankDbContext : DbContext
    {
        public BankDbContext() : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<HistoryLog> HistoryLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Card - User relationship (1-to-many)
            modelBuilder.Entity<Card>()
                .HasRequired(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
