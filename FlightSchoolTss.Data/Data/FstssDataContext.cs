using FlightSchoolTss.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightSchoolTss.Data.Data
{
    public partial class FstssDataContext : DbContext
    {
        public FstssDataContext()
        {
            
        }
        public FstssDataContext(DbContextOptions<FstssDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasOne(d => d.ConfigurationItem).WithMany(p => p.Configurations)
                    .HasForeignKey(d => d.ConfigurationItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Configurations_ConfigurationItems");

                entity.HasOne(d => d.Maintainable).WithMany(p => p.Configurations)
                    .HasForeignKey(d => d.MaintainableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Configurations_Maintainables");
            });

            modelBuilder.Entity<ConfigurationItem>(entity =>
            {
                entity.ToTable("ConfigurationItems");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemType).WithMany(p => p.ConfigurationItems)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfigurationItems_ItemTypes");
            });

            modelBuilder.Entity<HardwareConfiguration>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConfigurationItem).WithMany(p => p.HardwareConfigurations)
                    .HasForeignKey(d => d.ConfigurationItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareConfigurations_ConfigurationItems");
            });

            modelBuilder.Entity<HardwareSystem>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.HasOne(d => d.Maintainable).WithMany(p => p.HardwareSystems)
                    .HasForeignKey(d => d.MaintainableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareSystems_Maintainables");
                    
            });

            modelBuilder.Entity<HardwareVersion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.VersionDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.HardwareSystem).WithMany(p => p.HardwareVersions)
                    .HasForeignKey(d => d.HardwareSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareVersions_HardwareSystems");
            });

            modelBuilder.Entity<HardwareVersionsConfiguration>(entity =>
            {
                entity.HasOne(d => d.HardwareConfiguration).WithMany(p => p.HardwareVersionsConfigurations)
                    .HasForeignKey(d => d.HardwareConfigurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareVersionsConfigurations_HardwareConfigurations");

                entity.HasOne(d => d.HardwareVersion).WithMany(p => p.HardwareVersionsConfigurations)
                    .HasForeignKey(d => d.HardwareVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HardwareVersionsConfigurations_HardwareVersions");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lot>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Maintainable).WithMany(p => p.Lots)
                    .HasForeignKey(d => d.MaintainableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lots_Maintainables");

                entity.HasOne(d => d.Platform).WithMany(p => p.Lots)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lots_Platforms");
            });

            modelBuilder.Entity<Maintainer>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManModule>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lot).WithMany(p => p.ManModules)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManModules_Lots");

                entity.HasOne(d => d.Maintainable).WithMany(p => p.ManModules)
                    .HasForeignKey(d => d.MaintainableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManModules_Maintainables");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Maintainable).WithMany(p => p.Platforms)
                    .HasForeignKey(d => d.MaintainableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Platforms_Maintainables");

                entity.HasOne(d => d.Maintainer).WithMany(p => p.Platforms)
                    .HasForeignKey(d => d.MaintainerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Platforms_Maintainers");
            });

            modelBuilder.Entity<Simulator>(entity =>
            {
                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Maintainable).WithMany(p => p.Simulators)
                    .HasForeignKey(d => d.MaintainableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Simulators_Maintainables");

                entity.HasOne(d => d.Platform).WithMany(p => p.Simulators)
                    .HasForeignKey(d => d.PlatformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Simulators_Platforms");
            });

            modelBuilder.Entity<SoftwareLoad>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConfigurationItem).WithMany(p => p.SoftwareLoads)
                    .HasForeignKey(d => d.ConfigurationItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftwareLoads_ConfigurationItems");
            });

            modelBuilder.Entity<SoftwareSystem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Maintainable).WithMany(p => p.SoftwareSystems)
                    .HasForeignKey(d => d.MaintainableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftwareSystems_Maintainables");
            });

            modelBuilder.Entity<SoftwareVersion>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.VersionDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.SoftwareSystem).WithMany(p => p.SoftwareVersions)
                    .HasForeignKey(d => d.SoftwareSystemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftwareVersions_SoftwareSystems");
            });

            modelBuilder.Entity<SoftwareVersionsLoad>(entity =>
            {
                entity.HasOne(d => d.SoftwareLoad).WithMany(p => p.SoftwareVersionsLoads)
                    .HasForeignKey(d => d.SoftwareLoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftwareVersionsLoads_SoftwareLoads");

                entity.HasOne(d => d.SoftwareVersion).WithMany(p => p.SoftwareVersionsLoads)
                    .HasForeignKey(d => d.SoftwareVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftwareVersionsLoads_SoftwareVersions");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<Configuration> Configurations { get; set; }

        public virtual DbSet<ConfigurationItem> ConfigurationItems { get; set; }

        public virtual DbSet<HardwareConfiguration> HardwareConfigurations { get; set; }

        public virtual DbSet<HardwareSystem> HardwareSystems { get; set; }

        public virtual DbSet<HardwareVersion> HardwareVersions { get; set; }

        public virtual DbSet<HardwareVersionsConfiguration> HardwareVersionsConfigurations { get; set; }

        public virtual DbSet<ItemType> ItemTypes { get; set; }

        public virtual DbSet<Lot> Lots { get; set; }

        public virtual DbSet<Maintainable> Maintainables { get; set; }

        public virtual DbSet<Maintainer> Maintainers { get; set; }

        public virtual DbSet<ManModule> ManModules { get; set; }

        public virtual DbSet<Platform> Platforms { get; set; }

        public virtual DbSet<Simulator> Simulators { get; set; }

        public virtual DbSet<SoftwareLoad> SoftwareLoads { get; set; }

        public virtual DbSet<SoftwareSystem> SoftwareSystems { get; set; }

        public virtual DbSet<SoftwareVersion> SoftwareVersions { get; set; }

        public virtual DbSet<SoftwareVersionsLoad> SoftwareVersionsLoads { get; set; }

    }
}