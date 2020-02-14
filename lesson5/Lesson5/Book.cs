using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson51
{
    class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set;}
        public string Genre { get; set; }
        public bool IsPublished { get; set; } = false;
        public bool IsReviewed { get; set; } = false;
        public Author Author { get; set; }

        public Book(Guid id, string title, int pages, string genre, Author author)
        {
            Id = id;
            Title = title;
            Pages = pages;
            Genre = genre;
            Author = author;
        }
    }
}
