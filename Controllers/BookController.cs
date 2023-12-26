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

		// GET CREATE
		public IActionResult Create()
		{
			return View();
		}

		// POST CREATE
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

		// GET EDIT
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db?.Book.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		// POST EDIT
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Book obj)
		{
			if (ModelState.IsValid)
			{
				_db?.Book.Update(obj);
				_db?.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		// GET DELETE
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var obj = _db?.Book.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		// POST DELETE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db?.Book.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db?.Book.Remove(obj);
			_db?.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
