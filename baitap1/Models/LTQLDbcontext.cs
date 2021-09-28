using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace baitap1.Models
{
    public partial class LTQLDbContext : DbContext
    {
        public LTQLDbContext() : base("name=LTQLDbcontext")
        {
        }
        public virtual DbSet<Account> Account { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
            .Property(e => e.UserName)
            .IsUnicode(false);
            modelBuilder.Entity<Account>().Property(e => e.Password)
            .IsUnicode(false);

           
        }

        
    }
}