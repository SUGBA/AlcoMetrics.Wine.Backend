using Core.Models.WineRealizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.EF.ConnectionFroWine.Configuration
{
    /// <summary>
    /// Конфигурирование WineEvent сущности
    /// </summary>
    public class WineEventConfiguration : IEntityTypeConfiguration<WineEvent>
    {
        public void Configure(EntityTypeBuilder<WineEvent> builder)
        {
            builder.ToTable("WineEvent").Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
