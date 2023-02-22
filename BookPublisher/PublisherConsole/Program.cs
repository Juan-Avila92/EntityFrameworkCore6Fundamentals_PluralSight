// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PublisherData;
using PublisherDomain;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}


AddAuthorWithBooks();
GetAuthorsWithBooks();

void AddAuthorWithBooks()
{
    var author = new Author()
    {
        FirstName = "J.R.R",
        LastName = "Tolkien",
        Books = new List<Book>()
        {
            new Book()
            {
                Title = "The Silmarillion",
                PublishDate = new DateTime(1974, 1, 1)
            },
             new Book()
            {
                Title = "Beren And Luthien",
                PublishDate = new DateTime(2017, 1, 1)
            }
        }
    };

    using var context = new PubContext();

    context.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();

    var authors = context.Authors.Include(b => b.Books).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        author.Books.ForEach(book => PrintBookTitle(book.Title));
    }
}

void PrintBookTitle(string title)
{
    Console.WriteLine("*" + title);
}