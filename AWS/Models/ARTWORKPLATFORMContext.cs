using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AWS.Models
{
    public partial class ARTWORKPLATFORMContext : DbContext
    {
        public ARTWORKPLATFORMContext()
        {
        }

        public ARTWORKPLATFORMContext(DbContextOptions<ARTWORKPLATFORMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artwork> Artworks { get; set; } = null!;
        public virtual DbSet<ArtworkCustome> ArtworkCustomes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<LikeCollection> LikeCollections { get; set; } = null!;
        public virtual DbSet<OrderCusArt> OrderCusArts { get; set; } = null!;
        public virtual DbSet<OrderPremium> OrderPremia { get; set; } = null!;
        public virtual DbSet<OrderPremiumLog> OrderPremiumLogs { get; set; } = null!;
        public virtual DbSet<OrderRequire> OrderRequires { get; set; } = null!;
        public virtual DbSet<Ordertb> Ordertbs { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentCusArt> PaymentCusArts { get; set; } = null!;
        public virtual DbSet<Premium> Premia { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usertb> Usertbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LDHP36H\\SQLEXPRESS;Database=ARTWORKPLATFORM;User Id=sa;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.ToTable("Artwork");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.GenreId)
                    .HasMaxLength(50)
                    .HasColumnName("GenreID");

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.ImageUrl2).HasColumnName("ImageURL2");

                entity.Property(e => e.LikeTimes).HasColumnName("Like_times");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Reason).HasMaxLength(255);

                entity.Property(e => e.StatusProcessing).HasColumnName("Status_Processing");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.TimeProcessing)
                    .HasColumnType("datetime")
                    .HasColumnName("Time_Processing");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Artwork__GenreID__68487DD7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Artwork__UserID__693CA210");
            });

            modelBuilder.Entity<ArtworkCustome>(entity =>
            {
                entity.ToTable("Artwork_custome");

                entity.Property(e => e.ArtworkCustomeId)
                    .HasMaxLength(50)
                    .HasColumnName("Artwork_customeID");

                entity.Property(e => e.DeadlineDate).HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ArtworkCustomes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Artwork_c__UserI__6A30C649");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId)
                    .HasMaxLength(50)
                    .HasColumnName("CommentID");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.Text).HasMaxLength(255);

                entity.Property(e => e.Timestamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comment__UserID__6B24EA82");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.GenreId)
                    .HasMaxLength(50)
                    .HasColumnName("GenreID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<LikeCollection>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ArtworkId })
                    .HasName("PK__Like_Col__BA8FF647A2C2816B");

                entity.ToTable("Like_Collection");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.LikeCollections)
                    .HasForeignKey(d => d.ArtworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Like_Collection_Artwork");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LikeCollections)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Like_Coll__UserI__6C190EBB");
            });

            modelBuilder.Entity<OrderCusArt>(entity =>
            {
                entity.ToTable("Order_Cus_Art");

                entity.Property(e => e.OrderCusArtId)
                    .HasMaxLength(50)
                    .HasColumnName("Order_Cus_ArtID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OrderRequireId)
                    .HasMaxLength(50)
                    .HasColumnName("Order_requireID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("total");

                entity.HasOne(d => d.OrderRequire)
                    .WithMany(p => p.OrderCusArts)
                    .HasForeignKey(d => d.OrderRequireId)
                    .HasConstraintName("FK_Order_Cus_Art_Order_Require");
            });

            modelBuilder.Entity<OrderPremium>(entity =>
            {
                entity.ToTable("Order_Premium");

                entity.Property(e => e.OrderPremiumId)
                    .HasMaxLength(255)
                    .HasColumnName("Order_PremiumID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.PremiumId)
                    .HasMaxLength(50)
                    .HasColumnName("PremiumID");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Premium)
                    .WithMany(p => p.OrderPremia)
                    .HasForeignKey(d => d.PremiumId)
                    .HasConstraintName("FK__Order_Pre__Premi__6EF57B66");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderPremia)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_Premium_UserID");
            });

            modelBuilder.Entity<OrderPremiumLog>(entity =>
            {
                entity.ToTable("order_premium_log");

                entity.Property(e => e.OrderPremiumLogId)
                    .HasMaxLength(255)
                    .HasColumnName("Order_Premium_LogID");

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.OrderPremiumId)
                    .HasMaxLength(255)
                    .HasColumnName("Order_PremiumID");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TransactionCode).HasMaxLength(50);

                entity.HasOne(d => d.OrderPremium)
                    .WithMany(p => p.OrderPremiumLogs)
                    .HasForeignKey(d => d.OrderPremiumId)
                    .HasConstraintName("FK__order_pre__Order__70DDC3D8");
            });

            modelBuilder.Entity<OrderRequire>(entity =>
            {
                entity.ToTable("Order_Require");

                entity.Property(e => e.OrderRequireId)
                    .HasMaxLength(50)
                    .HasColumnName("Order_requireID");

                entity.Property(e => e.ArtworkCustomeId)
                    .HasMaxLength(50)
                    .HasColumnName("Artwork_customeID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.ArtworkCustome)
                    .WithMany(p => p.OrderRequires)
                    .HasForeignKey(d => d.ArtworkCustomeId)
                    .HasConstraintName("FK_Order_Require_Artwork_custome");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderRequires)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_Require_Usertb");
            });

            modelBuilder.Entity<Ordertb>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Ordertb__C3905BAF231B80F3");

                entity.ToTable("Ordertb");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Ordertbs)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK_Ordertb_Artwork");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ordertbs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Ordertb__UserID__73BA3083");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .HasColumnName("OrderID");

                entity.Property(e => e.TransactionCode).HasMaxLength(50);

                entity.Property(e => e.VnpTransDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payment__OrderID__75A278F5");
            });

            modelBuilder.Entity<PaymentCusArt>(entity =>
            {
                entity.ToTable("Payment_Cus_Art");

                entity.Property(e => e.PaymentCusArtId)
                    .HasMaxLength(50)
                    .HasColumnName("Payment_Cus_ArtID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OrderCusArtId)
                    .HasMaxLength(50)
                    .HasColumnName("Order_Cus_ArtID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TransctionCode).HasMaxLength(50);

                entity.HasOne(d => d.OrderCusArt)
                    .WithMany(p => p.PaymentCusArts)
                    .HasForeignKey(d => d.OrderCusArtId)
                    .HasConstraintName("FK_Payment_Cus_Art_Order_Cus_Art");
            });

            modelBuilder.Entity<Premium>(entity =>
            {
                entity.ToTable("Premium");

                entity.Property(e => e.PremiumId)
                    .HasMaxLength(50)
                    .HasColumnName("PremiumID");

                entity.Property(e => e.DayExpire)
                    .HasMaxLength(20)
                    .HasColumnName("Day_expire");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.ReportId)
                    .HasMaxLength(50)
                    .HasColumnName("ReportID");

                entity.Property(e => e.ArtworkId)
                    .HasMaxLength(50)
                    .HasColumnName("ArtworkID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Report__UserID__778AC167");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Id");

                entity.Property(e => e.RoleName).HasMaxLength(20);
            });

            modelBuilder.Entity<Usertb>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Usertb__1788CCACE766A587");

                entity.ToTable("Usertb");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.Bank).HasMaxLength(10);

                entity.Property(e => e.BankAccount).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasMaxLength(255);

                entity.Property(e => e.Fullname).HasMaxLength(255);

                entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

                entity.Property(e => e.Money).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.PremiumId)
                    .HasMaxLength(50)
                    .HasColumnName("PremiumID");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Id");

                entity.Property(e => e.Sex).HasMaxLength(10);

                entity.Property(e => e.StatusPost).HasColumnName("Status_Post");

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.HasOne(d => d.Premium)
                    .WithMany(p => p.Usertbs)
                    .HasForeignKey(d => d.PremiumId)
                    .HasConstraintName("FK__Usertb__PremiumI__7A672E12");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__Role___787EE5A0"),
                        r => r.HasOne<Usertb>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__UserI__797309D9"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__User_Rol__BA0867E71F06C15D");

                            j.ToTable("User_Role");

                            j.IndexerProperty<string>("UserId").HasMaxLength(50).HasColumnName("UserID");

                            j.IndexerProperty<string>("RoleId").HasMaxLength(50).HasColumnName("Role_Id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
