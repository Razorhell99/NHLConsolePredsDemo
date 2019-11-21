namespace NHLConsolePredsDemo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NHLContext : DbContext
    {
        public NHLContext()
            : base("name=NHLContext")
        {
        }

        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams>()
                .Property(e => e.TeamName)
                .IsUnicode(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.AwayTeamID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teams>()
                .HasMany(e => e.Games1)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.HomeTeamID)
                .WillCascadeOnDelete(false);
        }
    }
}
