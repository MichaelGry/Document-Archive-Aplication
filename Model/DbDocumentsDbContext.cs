using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Document_Archive.Model
{
    public class DbDocumentsDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Model.Folder> Folders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=documents.db");
        }
    }
    public class DataBaseDocuments : IDisposable
    {
        protected DbDocumentsDbContext dbc = new DbDocumentsDbContext();
        public void Dispose()
        {
            dbc.Dispose();
        }
        public DataBaseDocuments()
        {
            dbc.Database.EnsureCreated(); //create new data base if not exsist
        }
    }
}
