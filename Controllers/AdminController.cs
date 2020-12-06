using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Repository;

namespace Shop.Controllers
{
    [Authorize (Roles="admin")]
    public class AdminController : Controller
    {
        private readonly BookRepository repository;


        public AdminController(BookRepository repo)
        {
            repository = repo;
        }


        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int id)
        {
            var book = repository.GetObjectBook(id);
            return View(book);
        }


        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGame(book);
                TempData["message"] = string.Format("Изменения в книге \"{0}\" были сохранены", book.Name);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ViewResult Create()
        {
            return View("Edit", new Book());
        }

        
        public ActionResult Delete(int id)
        {
            var deletedGame = repository.DeleteBook(id);
            if (deletedGame != null)
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    deletedGame.Name);
            return RedirectToAction("Index");
        }
    }
}