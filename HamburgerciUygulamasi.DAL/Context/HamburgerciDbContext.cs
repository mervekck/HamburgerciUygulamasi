using HamburgerciUygulamasi.DAL.Entities.Concrete;
using HamburgerciUygulamasi.DAL.Mapping;
using HamburgerciUygulamasi.DAL.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciUygulamasi.DAL.Context
{
    public class HamburgerciDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public HamburgerciDbContext(DbContextOptions options) : base(options) 
        { 
        
        }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderExtra> OrderExtras { get; set; }
        public DbSet<OrderMenu> OrderMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.ApplyConfiguration(new ExtraMapping());
            builder.ApplyConfiguration(new MenuMapping());
            builder.ApplyConfiguration(new OrderMapping());
            builder.ApplyConfiguration(new OrderExtraMapping());
            builder.ApplyConfiguration(new OrderMenuMapping());
            
            base.OnModelCreating(builder);
        }
    }
}
