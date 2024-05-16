using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model;
using Library.DAL.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Data
{
    public class LibraryContext  :IdentityDbContext<AppUser>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options) {}

        
        public DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<BorrowingRecord> BorrowingRecords { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BorrowingRecord>()
                        .HasOne(br => br.Book)
                        .WithMany(b => b.BorrowingRecords)
                        .HasForeignKey(br => br.BookId);

            modelBuilder.Entity<BorrowingRecord>()
                        .HasOne(br => br.Patron)
                        .WithMany(p => p.BorrowingRecords)
                        .HasForeignKey(br => br.PatronId);
        }
    }
}
