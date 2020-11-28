using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AppDBContent _appDbContent;

        
        public AuthorController(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }

        
        [Route("Authors")]
        public ViewResult AuthorList(List<Author> authors)
        {
            List<Author> authorList = _appDbContent.Author.ToList();

            
            
            return View(authorList);
        }
        
        
        [Route("Authors/{id}")]
        public ViewResult Author(int id)
        {
            var author = _appDbContent.Author.FirstOrDefault(author => author.Id == id);

            if (author!= null)
            {
                var Books = new AuthorViewModel
                {
                    Books = _appDbContent.Book.Where(book =>book.Author.Id == id),
                    Author = author
                };
                
                return View(Books);
            }
            
            return View(null);
        }
    }
}