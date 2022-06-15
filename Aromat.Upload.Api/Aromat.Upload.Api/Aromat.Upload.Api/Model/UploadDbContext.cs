using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Model
{
    public class UploadDbContext : DbContext
    {
        private readonly string _connectionString = "Data Source=ADU;Initial Catalog=Aromat;User ID=arcadio;Password=pass1";

        public DbSet<FileData> FilesData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._connectionString);
        }
    }
}
