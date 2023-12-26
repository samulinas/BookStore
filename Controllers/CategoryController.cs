﻿using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext? _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category>? objList = _db?.Category;
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
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db?.Category.Add(obj);
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
            var obj = _db?.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

		// POST EDIT
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db?.Category.Update(obj);
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
			var obj = _db?.Category.Find(id);
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
            var obj = _db?.Category.Find(id);
			if (obj == null)
			{
                return NotFound();
			}
			_db?.Category.Remove(obj);
			_db?.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
