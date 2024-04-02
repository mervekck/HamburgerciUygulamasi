using HamburgerciUygulamasi.DAL.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Mapping
{
    public class OrderExtraMapping : IEntityTypeConfiguration<OrderExtra>
    {
        public void Configure(EntityTypeBuilder<OrderExtra> builder)
        {
            builder.HasKey(x => new { x.ExtraId, x.OrderId });

            builder.HasOne(x => x.Extra)
              .WithMany(x => x.OrderExtras)
              .HasForeignKey(x => x.ExtraId)
              .IsRequired();

            builder.HasOne(x => x.Order)
              .WithMany(x => x.OrderExtras)
              .HasForeignKey(x => x.OrderId)
              .IsRequired();
        }
    }
}
