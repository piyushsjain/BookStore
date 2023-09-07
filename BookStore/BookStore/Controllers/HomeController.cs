using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public BookModel Book { get; set; }
        public ViewResult Index()
        {
            //ViewBag.Title = "Webgentle";

            //dynamic data = new ExpandoObject();
            //data.Id = 1;
            //data.Name = "Nitish";
            //ViewBag.data = data;

            //ViewBag.Type = new BookModel() { Id = 5, Author = "This is Author" };

            ViewData["Property1"] = "Nitish Kaushik";
            ViewData["book"] = new BookModel() { Id = 5, Author = "Author" };

            CustomProperty = "Custom value";
            Title = "home page from controller";
            Book = new BookModel() { Id = 1, Title = "ASP.NET Core" };

            return View();
        }
        public ViewResult AboutUs()
        {
            Title = "about page from controller";
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}