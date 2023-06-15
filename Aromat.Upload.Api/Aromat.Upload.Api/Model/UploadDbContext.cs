using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Model
{
    public class UploadDbContext : DbContext
    {
        //private readonly string _connectionString = @"Server=tcp:aromat-db-server.database.windows.net,1433;Initial Catalog=AromatDb;Persist Security Info=False;User ID=aromat-admin;Password=Jaromir#68;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //private readonly string _connectionString = "Server=Localhost;User=LAPTOP-FAABQ3F4\\arcad;Database=Aromat;Trusted_Connection=True;";
        //private readonly string _connectionString = "Server=ADU;User=arcadio;Database=Aromat;Password=pass1;Trusted_Connection=True;";

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
