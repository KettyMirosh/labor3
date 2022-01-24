using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace labor3
{
    public partial class АэропортContext : DbContext
    {
        public АэропортContext()
        {
        }

        public АэропортContext(DbContextOptions<АэропортContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Билеты> Билетыs { get; set; } = null!;
        public virtual DbSet<Пассажиры> Пассажирыs { get; set; } = null!;
        public virtual DbSet<Регистрация> Регистрацияs { get; set; } = null!;
        public virtual DbSet<Рейсы> Рейсыs { get; set; } = null!;
        public virtual DbSet<Самолеты> Самолетыs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=D:\\\\\\\\Аэропорт.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Билеты>(entity =>
            {
                entity.HasKey(e => e.НомерБилета);

                entity.ToTable("Билеты");

                entity.HasIndex(e => e.НомерБилета, "IX_Билеты_Номер билета")
                    .IsUnique();

                entity.Property(e => e.НомерБилета)
                    .ValueGeneratedNever()
                    .HasColumnName("Номер билета");
            });

            modelBuilder.Entity<Пассажиры>(entity =>
            {
                entity.HasKey(e => e.НомерБилета);

                entity.ToTable("Пассажиры");

                entity.HasIndex(e => e.КодПассажира, "IX_Пассажиры_Код пассажира")
                    .IsUnique();

                entity.Property(e => e.НомерБилета)
                    .ValueGeneratedNever()
                    .HasColumnName("Номер билета");

                entity.Property(e => e.КодПассажира).HasColumnName("Код пассажира");
            });

            modelBuilder.Entity<Регистрация>(entity =>
            {
                entity.HasKey(e => e.Код);

                entity.ToTable("Регистрация");

                entity.HasIndex(e => e.Код, "IX_Регистрация_Код")
                    .IsUnique();

                entity.Property(e => e.Код).ValueGeneratedNever();

                entity.Property(e => e.ВыборМеста).HasColumnName("Выбор места");

                entity.Property(e => e.НомерйРейса).HasColumnName("Номерй рейса");

                entity.Property(e => e.РегистрацияПройдена).HasColumnName("Регистрация пройдена");
            });

            modelBuilder.Entity<Рейсы>(entity =>
            {
                entity.HasKey(e => e.НомерРейса);

                entity.ToTable("Рейсы");

                entity.HasIndex(e => e.НомерРейса, "IX_Рейсы_Номер рейса")
                    .IsUnique();

                entity.Property(e => e.НомерРейса)
                    .ValueGeneratedNever()
                    .HasColumnName("Номер рейса");

                entity.Property(e => e.Время).HasColumnType("NUMERIC");

                entity.Property(e => e.ГородПрибытия).HasColumnName("Город прибытия");

                entity.Property(e => e.ДатаРейса)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("Дата рейса");
            });

            modelBuilder.Entity<Самолеты>(entity =>
            {
                entity.HasKey(e => e.НомерСамолета);

                entity.ToTable("Самолеты");

                entity.HasIndex(e => e.НомерСамолета, "IX_Самолеты_Номер самолета")
                    .IsUnique();

                entity.Property(e => e.НомерСамолета)
                    .ValueGeneratedNever()
                    .HasColumnName("Номер самолета");

                entity.Property(e => e.ДатаВыпуска)
                    .HasColumnType("NUMERIC")
                    .HasColumnName("Дата выпуска");

                entity.Property(e => e.НазваниеСамолета).HasColumnName("Название самолета");

                entity.Property(e => e.ТипСамолета).HasColumnName("Тип самолета");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
