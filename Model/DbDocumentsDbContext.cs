﻿using System;
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
        public Document GetDocument(int idDoc)
        {
            return dbc.Documents.FirstOrDefault(d => d.Id == idDoc);
        }
        public Folder GetFolder(int idF)
        {
            return dbc.Folders.FirstOrDefault(f => f.Id == idF);
        }
        public int AddDocumentToDb(Document document)
        {
            if (document == null) throw new ArgumentNullException(
                 "An empty reference is given as an argument");
            if (document.Folder == null) throw new ArgumentException("No folder");
            if (dbc.Documents.Any(d => d.Id == document.Id))
                document.Id = dbc.Documents.Max(d => d.Id) + 1;
            //avoiding duplicate folders
            Folder folder = dbc.Folders.FirstOrDefault(f => f.Name == document.Folder.Name);
            if (folder != null) document.Folder = folder;

            dbc.Documents.Add(document);
            dbc.SaveChanges();
            return document.Id;
        }
    }
}
