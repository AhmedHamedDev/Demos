using ITPack.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingLists");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Localization)
                .HasConversion(x => x.ToString(), x => LocalizationReadModel.Create(x));

            builder.HasMany(x => x.Items)
                .WithOne(x => x.PackingList);
        }

        public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
        {
            builder.ToTable("PackingItems");
        }

    }
}
