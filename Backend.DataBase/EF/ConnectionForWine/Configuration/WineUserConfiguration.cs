using Core.Models.WineRealizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.EF.ConnectionForWine.Configuration
{
    /// <summary>
    /// Конфигурирование WineUser сущности
    /// </summary>
    public class WineUserConfiguration : IEntityTypeConfiguration<WineUser>
    {
        public void Configure(EntityTypeBuilder<WineUser> builder)
        {
            builder.Property(x=>x.Id).UseSerialColumn();
        }
    }
}
