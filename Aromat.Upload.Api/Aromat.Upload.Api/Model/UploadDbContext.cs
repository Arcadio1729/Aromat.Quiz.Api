using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Model
{
    public class UploadDbContext : DbContext
    {

        public DbSet<FileData> FileData { get; set; }

        public UploadDbContext(DbContextOptions<UploadDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(this._connectionString);
        //}
    }
}
