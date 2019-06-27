using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApp1.Models;

namespace WebApp1.Data
{
    public class ContextApp : DbContext
    {
        public ContextApp()
            : base("DefaultConnection")
        {

        }

        public virtual DbSet<Produts> Produt { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties().Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());
        }

    }
}