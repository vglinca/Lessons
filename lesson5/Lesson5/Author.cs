using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson51
{
    class Author
    {
        string _firstName;
        string _lastName;
        public string Name
        {
            get { return $"{_firstName} {_lastName}"; }
        }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; private set; }

        public Author(string firstName, string lastName, int age, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            Age = age;
            Email = email;
            Books = new List<Book>();
        }

        public void WriteBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Author {Name} has writtten new book with title \"{book.Title}\"");
        }

        public void PublishBook(string bookTitle)
        {
            var book = Books.Find(b => b.Title == bookTitle);
            if (book == null)
            {
                Console.WriteLine($"Could not find book with title \"{bookTitle}\"");
                return;
            }
            var index = Books.IndexOf(book);
            if (!Books[index].IsPublished)
            {
                Books[index].IsPublished = true;
                WriteDelimeter(); 
                Console.WriteLine($"\t\tPublishing a book..." +
                    $"\nBook with title \"{book.Title}\" of an author {book.Author.Name} has been successfully published.");
            } 
            else
            {
                WriteDelimeter();
                Console.WriteLine($"The book \"{book.Title}\" has already been published.");
            }
        }

        public void ReviewBook(string bookTitle)
        {
            var book = Books.Find(b => b.Title == bookTitle);
            if (book == null)
            {
                Console.WriteLine($"Could not find book with title \"{bookTitle}\"");
                return;
            }
            var index = Books.IndexOf(book);
            if (!Books[index].IsReviewed)
            {
                Books[index].IsReviewed = true;
                WriteDelimeter(); Console.WriteLine($"\t\tReviewed. \nTitle: {book.Title}\nAuthor: {book.Author.Name}" +
                    $"\nFor more info contact author on email: {book.Author.Email}");
            } else
            {
                WriteDelimeter();
                Console.WriteLine($"The book \"{book.Title}\" has already been reviewed.");
            }
        }

        private void WriteDelimeter()
        {
            Console.WriteLine("\n----------------------------------------------------------------------------------------\n");
        }
    }
}
