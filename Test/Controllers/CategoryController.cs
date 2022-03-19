using Test.Data;
using Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;



namespace Test.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "Admin, User")]
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            var result = objList;
            return View(objList);
        }

        


        // МЕТОД GET ДЛЯ ОПЕРАЦИИ CREATE
        [Authorize(Roles = "Admin, User")]
        public IActionResult Create()
        {
            return View();
        }

        // МЕТОД POST ДЛЯ ОПЕРАЦИИ CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Create(Category obj)
        {
            string Time = DateTime.Now.ToString();
            obj.Time = Time;
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }



        // РЕДАКТИРОВАНИЕ
        [Authorize(Roles = "Admin, User")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        // СОХРАНЕНИЕ В БД


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }





        // КОЛИЧЕСТВО ЗАПИСЕЙ
        [Authorize(Roles = "Admin, User")]
        public IActionResult Count()
        {            

            var obj = _db.Category.Count();
            return View(obj);
        }




        // РЕДАКТИРОВАНИЕ
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }





        // УДАЛЕНИЕ

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

 

    }

}
