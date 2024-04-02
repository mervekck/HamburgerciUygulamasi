using HamburgerciUygulamasi.DAL.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamburgerciUygulamasi.DAL.Enums;

namespace HamburgerciUygulamasi.DAL.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.Property(x => x.Size)
           .IsRequired()
           .HasConversion(
               v => v.ToString(),
               v => (Size)Enum.Parse(typeof(Size), v));

            builder.Property(x => x.AutoId).ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
