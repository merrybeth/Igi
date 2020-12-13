using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;

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
                repository.SaveBook(book);
                TempData["message"] = string.Format("Изменения в книге \"{0}\" были сохранены", book.Name);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Error(string text = "",string text_main = "")
        {
            TempData["text"] = text;
            TempData["text_main"] = text_main;
            return View();
        }
        
        public ViewResult Create()
        {
            return View("Edit", new Book());
        }

        
        public ActionResult Delete(int id)
        {
            var deletedGame = repository.DeleteBook(id);
            if (deletedGame != null)
                TempData["message"] = string.Format("Книга \"{0}\" была удалена",
                    deletedGame.Name);
            else
            {
                return Error("Возникла ошибка при удалении");
            }
            return RedirectToAction("Index");
        }
    }
}