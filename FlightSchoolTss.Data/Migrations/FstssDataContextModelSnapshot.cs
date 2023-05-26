﻿// <auto-generated />
using System;
using FlightSchoolTss.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightSchoolTss.Data.Migrations
{
    [DbContext(typeof(FstssDataContext))]
    partial class FstssDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfigurationItemId")
                        .HasColumnType("int");

                    b.Property<int>("MaintainableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationItemId");

                    b.HasIndex("MaintainableId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.ConfigurationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("ConfigurationItems", (string)null);
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfigurationItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationItemId");

                    b.ToTable("HardwareConfigurations");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaintainableId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("MaintainableId");

                    b.ToTable("HardwareSystems");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareVersion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("HardwareSystemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("VersionDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("HardwareSystemId");

                    b.ToTable("HardwareVersions");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareVersionsConfigurations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HardwareConfigurationId")
                        .HasColumnType("int");

                    b.Property<int>("HardwareVersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HardwareConfigurationId");

                    b.HasIndex("HardwareVersionId");

                    b.ToTable("HardwareVersionsConfigurations");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Lot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaintainableId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintainableId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Lots");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Maintainable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Maintainables");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Maintainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Maintainers");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.ManModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LotId")
                        .HasColumnType("int");

                    b.Property<int>("MaintainableId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LotId");

                    b.HasIndex("MaintainableId");

                    b.ToTable("ManModules");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MaintainableId")
                        .HasColumnType("int");

                    b.Property<int>("MaintainerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MaintainableId");

                    b.HasIndex("MaintainerId");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Simulator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MaintainableId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaintainableId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Simulators");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareLoad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfigurationItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationItemId");

                    b.ToTable("SoftwareLoads");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareSystem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("MaintainableId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MaintainableId");

                    b.ToTable("SoftwareSystems");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SoftwareSystemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VersionDate")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareSystemId");

                    b.ToTable("SoftwareVersions");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareVersionLoad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SoftwareLoadId")
                        .HasColumnType("int");

                    b.Property<int>("SoftwareVersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SoftwareLoadId");

                    b.HasIndex("SoftwareVersionId");

                    b.ToTable("SoftwareVersionsLoads");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Configuration", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.ConfigurationItem", "ConfigurationItem")
                        .WithMany("Configurations")
                        .HasForeignKey("ConfigurationItemId")
                        .IsRequired()
                        .HasConstraintName("FK_Configurations_ConfigurationItems");

                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainable", "Maintainable")
                        .WithMany("Configurations")
                        .HasForeignKey("MaintainableId")
                        .IsRequired()
                        .HasConstraintName("FK_Configurations_Maintainables");

                    b.Navigation("ConfigurationItem");

                    b.Navigation("Maintainable");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.ConfigurationItem", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.ItemType", "ItemType")
                        .WithMany("ConfigurationItems")
                        .HasForeignKey("ItemTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_ConfigurationItems_ItemTypes");

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareConfiguration", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.ConfigurationItem", "ConfigurationItem")
                        .WithMany("HardwareConfigurations")
                        .HasForeignKey("ConfigurationItemId")
                        .IsRequired()
                        .HasConstraintName("FK_HardwareConfigurations_ConfigurationItems");

                    b.Navigation("ConfigurationItem");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareSystem", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainable", "Maintainable")
                        .WithMany("HardwareSystems")
                        .HasForeignKey("MaintainableId")
                        .IsRequired()
                        .HasConstraintName("FK_HardwareSystems_Maintainables");

                    b.Navigation("Maintainable");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareVersion", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.HardwareSystem", "HardwareSystem")
                        .WithMany("HardwareVersions")
                        .HasForeignKey("HardwareSystemId")
                        .IsRequired()
                        .HasConstraintName("FK_HardwareVersions_HardwareSystems");

                    b.Navigation("HardwareSystem");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareVersionsConfigurations", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.HardwareConfiguration", "HardwareConfiguration")
                        .WithMany("HardwareVersionsConfigurations")
                        .HasForeignKey("HardwareConfigurationId")
                        .IsRequired()
                        .HasConstraintName("FK_HardwareVersionsConfigurations_HardwareConfigurations");

                    b.HasOne("FlightSchoolTss.Data.Entities.HardwareVersion", "HardwareVersion")
                        .WithMany("HardwareVersionsConfigurations")
                        .HasForeignKey("HardwareVersionId")
                        .IsRequired()
                        .HasConstraintName("FK_HardwareVersionsConfigurations_HardwareVersions");

                    b.Navigation("HardwareConfiguration");

                    b.Navigation("HardwareVersion");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Lot", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainable", "Maintainable")
                        .WithMany("Lots")
                        .HasForeignKey("MaintainableId")
                        .IsRequired()
                        .HasConstraintName("FK_Lots_Maintainables");

                    b.HasOne("FlightSchoolTss.Data.Entities.Platform", "Platform")
                        .WithMany("Lots")
                        .HasForeignKey("PlatformId")
                        .IsRequired()
                        .HasConstraintName("FK_Lots_Platforms");

                    b.Navigation("Maintainable");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.ManModule", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.Lot", "Lot")
                        .WithMany("ManModules")
                        .HasForeignKey("LotId")
                        .IsRequired()
                        .HasConstraintName("FK_ManModules_Lots");

                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainable", "Maintainable")
                        .WithMany("ManModules")
                        .HasForeignKey("MaintainableId")
                        .IsRequired()
                        .HasConstraintName("FK_ManModules_Maintainables");

                    b.Navigation("Lot");

                    b.Navigation("Maintainable");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Platform", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainable", "Maintainable")
                        .WithMany("Platforms")
                        .HasForeignKey("MaintainableId")
                        .IsRequired()
                        .HasConstraintName("FK_Platforms_Maintainables");

                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainer", "Maintainer")
                        .WithMany("Platforms")
                        .HasForeignKey("MaintainerId")
                        .IsRequired()
                        .HasConstraintName("FK_Platforms_Maintainers");

                    b.Navigation("Maintainable");

                    b.Navigation("Maintainer");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Simulator", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainable", "Maintainable")
                        .WithMany("Simulators")
                        .HasForeignKey("MaintainableId")
                        .IsRequired()
                        .HasConstraintName("FK_Simulators_Maintainables");

                    b.HasOne("FlightSchoolTss.Data.Entities.Platform", "Platform")
                        .WithMany("Simulators")
                        .HasForeignKey("PlatformId")
                        .IsRequired()
                        .HasConstraintName("FK_Simulators_Platforms");

                    b.Navigation("Maintainable");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareLoad", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.ConfigurationItem", "ConfigurationItem")
                        .WithMany("SoftwareLoads")
                        .HasForeignKey("ConfigurationItemId")
                        .IsRequired()
                        .HasConstraintName("FK_SoftwareLoads_ConfigurationItems");

                    b.Navigation("ConfigurationItem");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareSystem", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.Maintainable", "Maintainable")
                        .WithMany("SoftwareSystems")
                        .HasForeignKey("MaintainableId")
                        .IsRequired()
                        .HasConstraintName("FK_SoftwareSystems_Maintainables");

                    b.Navigation("Maintainable");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareVersion", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.SoftwareSystem", "SoftwareSystem")
                        .WithMany("SoftwareVersions")
                        .HasForeignKey("SoftwareSystemId")
                        .IsRequired()
                        .HasConstraintName("FK_SoftwareVersions_SoftwareSystems");

                    b.Navigation("SoftwareSystem");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareVersionLoad", b =>
                {
                    b.HasOne("FlightSchoolTss.Data.Entities.SoftwareLoad", "SoftwareLoad")
                        .WithMany("SoftwareVersionsLoads")
                        .HasForeignKey("SoftwareLoadId")
                        .IsRequired()
                        .HasConstraintName("FK_SoftwareVersionsLoads_SoftwareLoads");

                    b.HasOne("FlightSchoolTss.Data.Entities.SoftwareVersion", "SoftwareVersion")
                        .WithMany("SoftwareVersionsLoads")
                        .HasForeignKey("SoftwareVersionId")
                        .IsRequired()
                        .HasConstraintName("FK_SoftwareVersionsLoads_SoftwareVersions");

                    b.Navigation("SoftwareLoad");

                    b.Navigation("SoftwareVersion");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.ConfigurationItem", b =>
                {
                    b.Navigation("Configurations");

                    b.Navigation("HardwareConfigurations");

                    b.Navigation("SoftwareLoads");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareConfiguration", b =>
                {
                    b.Navigation("HardwareVersionsConfigurations");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareSystem", b =>
                {
                    b.Navigation("HardwareVersions");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.HardwareVersion", b =>
                {
                    b.Navigation("HardwareVersionsConfigurations");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.ItemType", b =>
                {
                    b.Navigation("ConfigurationItems");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Lot", b =>
                {
                    b.Navigation("ManModules");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Maintainable", b =>
                {
                    b.Navigation("Configurations");

                    b.Navigation("HardwareSystems");

                    b.Navigation("Lots");

                    b.Navigation("ManModules");

                    b.Navigation("Platforms");

                    b.Navigation("Simulators");

                    b.Navigation("SoftwareSystems");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Maintainer", b =>
                {
                    b.Navigation("Platforms");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.Platform", b =>
                {
                    b.Navigation("Lots");

                    b.Navigation("Simulators");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareLoad", b =>
                {
                    b.Navigation("SoftwareVersionsLoads");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareSystem", b =>
                {
                    b.Navigation("SoftwareVersions");
                });

            modelBuilder.Entity("FlightSchoolTss.Data.Entities.SoftwareVersion", b =>
                {
                    b.Navigation("SoftwareVersionsLoads");
                });
#pragma warning restore 612, 618
        }
    }
}
