using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlvanUastWebsiteM.Models
{
    public partial class AlvanUastDBContext : DbContext
    {

        public AlvanUastDBContext(DbContextOptions<AlvanUastDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<Timeline> Timelines { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySQL("server=localhost;port=3306;user=alvandbuser;password=Alvandb@123123;database=testdb;CharSet=utf8"");
                optionsBuilder.UseMySQL("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Body).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ParentName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.HasIndex(e => e.NewsCategoryId)
                    .HasName("FK_News_News_Category");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NewsCategoryId)
                    .HasColumnName("News_Category_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pics)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.NewsCategory)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.NewsCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_News_News_Category");
            });

            modelBuilder.Entity<NewsCategory>(entity =>
            {
                entity.ToTable("news_category");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.ToTable("notice");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Timeline>(entity =>
            {
                entity.ToTable("timeline");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Emtehanat).HasColumnType("date");

                entity.Property(e => e.EntekhabVahed).HasColumnType("date");

                entity.Property(e => e.HazfoEzafe).HasColumnType("date");

                entity.Property(e => e.Nimsal).HasColumnType("int(11)");

                entity.Property(e => e.PayaneKelasha).HasColumnType("date");

                entity.Property(e => e.ShoroeKelasha).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
