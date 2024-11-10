using Microsoft.AspNetCore.Mvc;
using ToDoListMVC.Data;
using ToDoListMVC.Entities;
using ToDoListMVC.Models;

namespace ToDoListMVC.Controllers
{
	public class ActivetiesController : Controller
	{
        public ActivetiesController(ApplicationDbContext Db)
        {
            this.Db = Db;
        }

        public ApplicationDbContext Db { get; }

        public IActionResult Index()
		{
            var Activeties = Db.Activeties;
			return View(Activeties);
		}
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(ActivetyVM model)
        {
            var activety = new Activety { Name = model.Name };
            Db.Activeties.Add(activety);
            Db.SaveChanges();
                
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var activety = Db.Activeties.Find(Id);

            return View(activety);
        }
		[HttpPost]
		public IActionResult Edit(ActivetyVM model)
		{
			var activety = Db.Activeties.Find(model.Id);
            activety.Name = model.Name;
            activety.UpdateTime= DateTime.Now;
            Db.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult Delete(int Id)
		{
			var activety = Db.Activeties.Find(Id);

			return View(activety);
		}
		[HttpPost]
		public IActionResult Delete(ActivetyVM model)
		{
			var activety = Db.Activeties.Find(model.Id);
			activety.Name = model.Name;
            Db.Remove(activety);
			Db.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
