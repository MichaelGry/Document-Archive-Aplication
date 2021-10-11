using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Document_Archive.Model
{
    public class DbDocumentsDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Folder> Folders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=documents.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasOne(d => d.Folder).WithMany(f => f.Documents);
        }
    }
    public class DataBaseDocuments : IDisposable
    {
        protected DbDocumentsDbContext dbc = new DbDocumentsDbContext();
        public List<Document> Documents 
        { get 
            {
                return dbc.Documents.Select(d => d).ToList();
            } 
        }  
        public List<Folder> Folders
        {
            get
            {
                return dbc.Folders.OrderBy(f => f.Name).ToList();
            }
        }
        public void Dispose()
        {
            dbc.Dispose();
        }
        public DataBaseDocuments()
        {
            dbc.Database.EnsureCreated(); //create new data base if not exsist
        }
        public Document GetDocumentById(int idDoc)
        {
            return dbc.Documents.FirstOrDefault(d => d.Id == idDoc);
        }
        public List<Folder> GetFullContentFolders()
        {
            return dbc.Folders.Include(f => f.Documents).ToList();
        }
        public List<Document> GetFullContentDocuments()
        {
            return dbc.Documents.Include(d => d.Folder).ToList();
        }
        public Folder GetFolderByName(string name)
        {
            try
            {
                return dbc.Folders.Include(f => f.Documents).FirstOrDefault(f => f.Name == name);
            }
            catch (Exception exc)
            {
                Console.WriteLine("An error occured while downloading a folder\n" + exc.Message + 
                    "\n\nPress aby key to continue...");
                _ = Console.ReadKey();
                return null;
            }
        }
        public int AddDocumentToDb(Document document)
        {
            Console.WriteLine("Adds the documets...");
            if (document == null) throw new ArgumentNullException(
                 "An empty reference is given as an argument");
            if (document.Folder == null) throw new ArgumentException("No folder");
            if (dbc.Documents.Any(d => d.Id == document.Id))
                document.Id = dbc.Documents.Max(d => d.Id) + 1;
            //avoiding duplicate folders
            Folder folder = dbc.Folders.ToArray().FirstOrDefault(f => f.Name == document.Folder.Name);
            if (folder != null) 
            {
                document.Folder = folder;
            }

            dbc.Documents.Add(document);
            dbc.SaveChanges();
            Console.WriteLine("Added succesfull.\nPress any key to continue...");
            Console.ReadLine();
            return document.Id;
        }
        public void DeleteDocumentById(int id)
        {
            try
            {
                Document docToDelete = Documents.FirstOrDefault(d => d.Id == id);
                if (docToDelete == null)
                {
                    Console.WriteLine("No document with id " + id + "\nPress any key to continue...");
                    _ = Console.ReadKey();
                    return;
                }
                dbc.Documents.Remove(docToDelete);
                if (docToDelete.Folder.Documents.Count == 1) dbc.Folders.Remove(docToDelete.Folder);
                dbc.SaveChanges();
                Console.WriteLine("Deletin sucessfull\nPress any key to continue...");
                _ = Console.ReadKey();
            } 
            catch (Exception exc)
            {
                Console.WriteLine("Failure while deleting document\n" + exc.Message);
            }
        }
        public void SaveToXml(string path)
        {
            XDocument xDocument = new(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("folders", 
                    from folder in GetFullContentFolders()
                    orderby folder.Name
                    select new XElement("folder",
                        new XAttribute("id", folder.Id.ToString()),
                        new XElement("name", folder.Name),
                        new XElement("documents", 
                            from document in folder.Documents
                            select new XElement("document",
                                new XAttribute("id", document.Id.ToString()),
                                new XElement("name", document.Name),
                                new XElement("category", document.Category),
                                new XElement("creation_date", document.CreationDate.ToString("D"))
                            )
                        )
                    )
                )
            );
            xDocument.Save(path);
            Console.WriteLine("Export to xml file successful\nPress enter to continue...");
            _ = Console.ReadLine();
        }
    }
}
