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
    public class OrderMenuMapping : IEntityTypeConfiguration<OrderMenu>
    {
        public void Configure(EntityTypeBuilder<OrderMenu> builder)
        {
            builder.HasKey(x => new { x.MenuId, x.OrderId });

            builder.HasOne(x => x.Menu)
              .WithMany(x => x.OrderMenus)
              .HasForeignKey(x => x.MenuId)
              .IsRequired();

            builder.HasOne(x => x.Order)
              .WithMany(x => x.OrderMenus)
              .HasForeignKey(x => x.OrderId)
              .IsRequired();
        }
    }
}
