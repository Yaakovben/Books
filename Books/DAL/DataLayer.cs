using Microsoft.EntityFrameworkCore;
using Books.Models;

namespace Books.DAL
{
    // DbContext קלאס שמייצג את שכבת הנתונים,יורש מקלאס בשם 
    public class DataLayer : DbContext
    {
        //קונסטרקטור שמקבל מחרוזת חיבור ומעביר אותה לקונסטרקטור של הקלאס האב
        public DataLayer(string connectinString) : base(GetOptions(connectinString))
        {
            //פונקצייה שמוודאת שהדאטה בייס נוצר
            Database.EnsureCreated();

            //להכניס נתונים בפעם הראשונה
            Seed();
            
        }
        private void Seed() 
        {
            Library library = AddDefaultLibrary();
            Shelf shelf = AddDefaultShelf(library);
            Book books = AddDefaultBook(shelf); 
            
            SaveChanges();


        }



        //פונקציית הוספה לספריות
        private Library AddDefaultLibrary()
        {
            Library library;
            if (!Libraries.Any())
            {
                library = new Library { Genre = "תורה" };
                Libraries.Add(library);
            }
            else
            {
                library = Libraries.First();
            }


            return library;
        }

        //פונקציית הוספה למדפים
        private Shelf AddDefaultShelf(Library lib)
        {
            Shelf shelf;
            if (!Shelves.Any())
            {
                shelf = new Shelf {Library = lib,Height = 15 };
                Shelves.Add(shelf);
            }
            else
            {
                shelf = Shelves.First();
            }
            return shelf;
        }
        //פונקציית הוספה לספרים
        private Book AddDefaultBook(Shelf shl)
        {
            Book book;
            if (!Bookss.Any())
            {
                book = new Book { Name = "חומש בראשית",Shelf = shl,Height =12 };
                Bookss.Add(book);
            }
            else
            {
                book = Bookss.First();
            }
            return book;
        }


        //יצירת טבלאות עם כל הנתונים
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Book> Bookss { get; set; }
        
       

        // פונקציה שמחזירה את אפשרויות ההתחברות למסד הנתונים
        private static DbContextOptions GetOptions(string connectinString)
        {
            return SqlServerDbContextOptionsExtensions 
                .UseSqlServer(new DbContextOptionsBuilder(), connectinString)
                .Options;
                
        }

    }
}
