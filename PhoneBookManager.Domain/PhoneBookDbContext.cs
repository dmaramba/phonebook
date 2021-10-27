using Microsoft.EntityFrameworkCore;
using PhoneBookManager.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhoneBookManager.Domain
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
                    : base(options)
        {
        }

        public DbSet<PhoneBook> PhoneBooks { get; set; }

        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Entry>()
                .HasKey(p => p.Id);

            builder.Entity<Entry>()
               .HasOne(p => p.PhoneBook)
               .WithMany(b => b.Entries);

            builder.Entity<PhoneBook>().HasData(new PhoneBook { Id = 1, Name = "Default PhoneBook" });
     
            base.OnModelCreating(builder);
        }
    }
}
