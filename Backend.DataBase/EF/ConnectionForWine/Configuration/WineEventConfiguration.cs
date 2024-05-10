using Core.Models.WineRealizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.EF.ConnectionForWine.Configuration
{
    /// <summary>
    /// Конфигурирование WineEvent сущности
    /// </summary>
    public class WineEventConfiguration : IEntityTypeConfiguration<WineEvent>
    {
        public void Configure(EntityTypeBuilder<WineEvent> builder)
        {
            builder
               .HasOne(m => m.ResultIndicator)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(m => m.DesiredIndicator)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(m => m.Ingridients)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.DesiredIndicatorId).IsUnique(false);
            builder.HasIndex(x => x.ResultIndicatorId).IsUnique(false);
        }
    }
}
