using System;
using System.Collections.Generic;
using System.Text;
using FluentApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<LogAudit>();

            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Usuario>().Property(u => u.Id).ValueGeneratedNever();
            builder.Entity<Usuario>().Property(u => u.Nome).HasMaxLength(100).IsRequired();
            builder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(150).IsRequired();

            builder.Entity<Cliente>().ToTable("Clientes");
            builder.Entity<Cliente>().HasKey(c => c.Id);
            builder.Entity<Cliente>().Property(c => c.Telefone).HasMaxLength(20).IsRequired();
            builder.Entity<Cliente>().Property(c => c.Cidade).HasMaxLength(50).IsRequired();
            builder.Entity<Cliente>().Property(c => c.Endereco).HasMaxLength(100).IsRequired();
            builder.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(80).IsRequired();

            builder.Entity<Pedido>().ToTable("Pedidos");
            builder.Entity<Pedido>().HasKey(p => p.Id);
            builder.Entity<Pedido>().HasOne(c => c.Cliente).WithMany(p => p.ListaPedidos).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
