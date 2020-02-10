using System;
using System.Collections.Generic;

namespace Lesson51
{
    class Program
    {
        static void Main(string[] args)
        {
            var author = new Author("Stephen", "Hawking", 70, "st_hawking@mail.com");
            author.WriteBook(new Book(Guid.Parse("0d4abe63-cf70-446c-ba23-cbbcc27ea8e7"),
                "A short brief of time", 256, "Science", author));
            author.WriteBook(new Book(Guid.Parse("2b1173c8-08a0-4601-befa-841e83fc1764"),
                "Brief answers to the big questions", 256, "Science", author));
            author.WriteBook(new Book(Guid.Parse("4bc808ee-d803-48a4-ab0f-40d3a5f18ccb"),
                "The theory of everything", 450, "Science", author));

            author.PublishBook("A short brief of time");
            author.ReviewBook("A short brief of time");
            author.PublishBook("A short brief of time");
            author.ReviewBook("Brief answers to the big questions");
        }
    }
}
