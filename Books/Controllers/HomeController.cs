using Books.DAL;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //���� �� �������
        public IActionResult Library()
        {
            List<Library> libraries = Data.Get.Libraries.ToList();

            return View(libraries);
        }
        //���� �� ������
        public IActionResult Shelf()
        {

            List<Shelf> shelves = Data.Get.Shelves.ToList();
            return View(shelves);
        }
        //���� �� ������
        public IActionResult Book()
        {
            List<Book> bookss = Data.Get.Bookss.ToList();
            return View(bookss);
        }
        //����� ���� ������ ������
        public IActionResult Create()
        {
            return View(new Library());
        }
        //����� ������
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddLibrary(Library library)
        {
            Data.Get.Libraries.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }
       
        

        //����� ���� ������ ��� �������� ����
        public IActionResult CreateShelf2(int id)
        {
        

            ViewBag.Id = id;
            return View(new Shelf());

        }
        //����� ��� ������� ���� 
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf2(Shelf shelf)
        {
            Library? FromDb = Data.Get.Libraries.FirstOrDefault(l => l.Id == shelf.l_id);
            if (FromDb == null)
            {
                return NotFound();
            }
            shelf.Library = FromDb;
            Data.Get.Shelves.Add(shelf);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }
        //���� ����� ��� ������� ����  
        public IActionResult CreateBook2(int id)
        {
            

            ViewBag.Id = id;
            return View(new Book());

        }
        //����� ��� ������� ���� 
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBook2(Book book)
        {
            
            Shelf? FromDb = Data.Get.Shelves.FirstOrDefault(l => l.Id == book.book_id);
            if (FromDb == null)
            {
                return NotFound();
            }
            book.Shelf = FromDb;
            Data.Get.Bookss.Add(book);
            if (book.Height > FromDb.Height)
            {
                return View("Errorr");
            }
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }
      

        public IActionResult Errorr()
        {
           return View();
        }
            






























        public IActionResult Index()
        {
            List<Library> libraries = Data.Get.Libraries.ToList();
            return View(libraries);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
