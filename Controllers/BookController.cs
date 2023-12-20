using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext? _db;
        public BookController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book>? objList = _db?.Book;
            return View(objList);
        }

		// GET
		public IActionResult Create()
		{
			return View();
		}

		// POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Book obj)
		{
			if (ModelState.IsValid)
			{
				_db?.Book.Add(obj);
				_db?.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}
