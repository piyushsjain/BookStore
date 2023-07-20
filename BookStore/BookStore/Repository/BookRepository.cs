using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBooks(string title, string authorName)  
        {
            return DataSource().Where(x => x.Title == title && x.Author == authorName).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC",Author="Nitish"},
                new BookModel(){Id=2, Title="Java",Author="Nitish"},
                new BookModel(){Id=3, Title="C#",Author="Monika"},
                new BookModel(){Id=4, Title="Dotnet",Author="Webgentle"},
                new BookModel(){Id=5, Title="Angular",Author="Harshs"}
            };
        }
    }
}
