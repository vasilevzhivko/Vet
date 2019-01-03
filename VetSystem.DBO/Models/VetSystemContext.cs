using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VetSystem.DBO.Models
{
    public partial class VetSystemContext : DbContext
    {
        public VetSystemContext()
        {
        }

        public VetSystemContext(DbContextOptions<VetSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnimalSubTypes> AnimalSubTypes { get; set; }
        public virtual DbSet<AnimalTypes> AnimalTypes { get; set; }
        public virtual DbSet<DoctorSpecialties> DoctorSpecialties { get; set; }
        public virtual DbSet<DoctorSpecialtiesDoctors> DoctorSpecialtiesDoctors { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<PetStatus> PetStatus { get; set; }
        public virtual DbSet<Pets> Pets { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=VetSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AnimalSubTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentAnimalNavigation)
                    .WithMany(p => p.AnimalSubTypes)
                    .HasForeignKey(d => d.ParentAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalSubTypes_ParentAnimal");
            });

            modelBuilder.Entity<AnimalTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorSpecialties>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DoctorSpecialtiesDoctors>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DoctorSpecialtiesId).HasColumnName("DoctorSpecialtiesID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorSpecialtiesDoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSpecialtiesDoctors_DoctorID");

                entity.HasOne(d => d.DoctorSpecialties)
                    .WithMany(p => p.DoctorSpecialtiesDoctors)
                    .HasForeignKey(d => d.DoctorSpecialtiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSpecialtiesDoctors_DoctorSpecialtiesID");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Owners>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PetStatus>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PetId).HasColumnName("PetID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PetStatus)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetStatus_DoctorID");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetStatus)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetStatus_PetID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PetStatus)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetStatus_StatusID");
            });

            modelBuilder.Entity<Pets>(entity =>
            {
                entity.Property(e => e.AnimalSubTypeId).HasColumnName("AnimalSubTypeID");

                entity.Property(e => e.AnimalTypeId).HasColumnName("AnimalTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.HasOne(d => d.AnimalSubType)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.AnimalSubTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pets_AnimalSubType");

                entity.HasOne(d => d.AnimalType)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.AnimalTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pets_AnimalType");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pets_Owner");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });
        }
    }
}
