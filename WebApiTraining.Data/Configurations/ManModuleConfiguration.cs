using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiTraining.Data.Entities;

namespace WebApiTraining.Data.Configurations;
internal class ManModuleConfiguration : IEntityTypeConfiguration<ManModule>
{
    public void Configure(EntityTypeBuilder<ManModule> modelBuilder)
    {
        modelBuilder
            .HasData(
                new ManModule { Id = 1, LotId = 1, Name="MM01"},
                new ManModule { Id = 2, LotId = 1, Name = "MM02" },
                new ManModule { Id = 3, LotId = 1, Name = "MM03" },
                new ManModule { Id = 4, LotId = 1, Name = "MM04" },
                new ManModule { Id = 5, LotId = 1, Name = "MM05" },
                new ManModule { Id = 6, LotId = 1, Name = "MM06" },
                new ManModule { Id = 7, LotId = 2, Name = "MM07" },
                new ManModule { Id = 8, LotId = 2, Name = "MM08" },
                new ManModule { Id = 9, LotId = 2, Name = "MM09" },
                new ManModule { Id = 10, LotId = 2, Name = "MM10" },
                new ManModule { Id = 11, LotId = 2, Name = "MM11" },
                new ManModule { Id = 12, LotId = 2, Name = "MM12" },
                new ManModule { Id = 13, LotId = 3, Name = "MM13" },
                new ManModule { Id = 14, LotId = 3, Name = "MM14" },
                new ManModule { Id = 15, LotId = 3, Name = "MM15" },
                new ManModule { Id = 16, LotId = 3, Name = "MM16" },
                new ManModule { Id = 17, LotId = 3, Name = "MM17" },
                new ManModule { Id = 18, LotId = 3, Name = "MM18" }
            );
    }
}