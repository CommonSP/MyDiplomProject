using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyDiplomProject.Entityes;

namespace MyDiplomProject
{
    public partial class MyDiplomDatabaseContext : DbContext
    {
        public MyDiplomDatabaseContext()
        {
        }

        public MyDiplomDatabaseContext(DbContextOptions<MyDiplomDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeCategory> AgeCategory { get; set; }
        public virtual DbSet<ChatRooms> ChatRooms { get; set; }
        public virtual DbSet<Children> Children { get; set; }
        public virtual DbSet<EatMenus> EatMenus { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<UserInChatRoom> UserInChatRoom { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ImageGroups> ImageGroups { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ChatRooms>(entity =>
            {
                entity.HasKey(e => e.ChatRoomId);

                entity.Property(e => e.NameRoom).HasMaxLength(20);
            });

            modelBuilder.Entity<Children>(entity =>
            {
                entity.HasKey(e => e.ChildId);

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_Relationship18");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_Relationship19");

                entity.Property(e => e.Burn).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("ВходитВГруппу");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("ЯвляетсяРодителем");
            });

            modelBuilder.Entity<EatMenus>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_Relationship24");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Eat).IsRequired();

                entity.Property(e => e.Mod)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EatMenus)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("МенюГруппы");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_Relationship26");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("ОтноситсяКВозрастнойГруппе");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.HasIndex(e => e.ChatRoomId)
                    .HasName("IX_Relationship27");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_Relationship28");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.ChatRoom)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("СообщениеВЧате");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ОтправительСообщения");
            });

            modelBuilder.Entity<Schedules>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_Relationship25");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Event).IsRequired();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("РасписаниеГруппы");
            });

            modelBuilder.Entity<ImageGroups>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_Relationship55");

                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(d => d.Groups)
                    .WithMany(p => p.ImageGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("ФотоГруппы");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasIndex(e => e.ChildId)
                    .HasName("IX_Relationship55");

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Children)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ChildId)
                    .HasConstraintName("КомментарийКРебёнку");
            });

            modelBuilder.Entity<UserInChatRoom>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ChatRoomId });

                entity.HasOne(d => d.ChatRoom)
                    .WithMany(p => p.UserInChatRoom)
                    .HasForeignKey(d => d.ChatRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship31");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInChatRoom)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("СостоитВЧате");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.GroupId)
                    .HasName("IX_Relationship21");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Phone).HasMaxLength(16);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("ЯвляетсяВоспитателем");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
