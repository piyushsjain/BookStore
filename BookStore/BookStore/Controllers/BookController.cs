using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return _bookRepository.SearchBooks(title, authorName);
        }
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()   // for default language selection
            {
                //Language = "2"
            };

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            //ViewBag.Language = new List<string>() { "Hindi", "English", "Sanskrit" };
            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //});
            //var group1 = new SelectListGroup() { Name = "Group 1", Disabled = true };
            //var group2 = new SelectListGroup() { Name = "Group 2" };

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "Hindi", Value = "1", Group = group1},
            //    new SelectListItem(){Text = "English", Value = "2", Disabled = true, Selected = true, Group = group1},
            //    new SelectListItem(){Text = "Sanskrit", Value = "3", Group = group2},
            //    new SelectListItem(){Text = "Prakrit", Value = "4", Group = group2},
            //};

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if(id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");


            //ViewBag.Language = new List<string>() { "Hindi", "English", "Sanskrit" };
            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //});

            //var group1 = new SelectListGroup() { Name = "Group 1", Disabled = true };
            //var group2 = new SelectListGroup() { Name = "Group 2" };

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "Hindi", Value = "1", Group = group1},
            //    new SelectListItem(){Text = "English", Value = "2", Disabled = true, Selected = true, Group = group1},
            //    new SelectListItem(){Text = "Sanskrit", Value = "3", Group = group2},
            //    new SelectListItem(){Text = "Prakrit", Value = "4", Group = group2},
            //};

            //ModelState.AddModelError("", "This is Custom error message");
            return View();
        }
    }
}
