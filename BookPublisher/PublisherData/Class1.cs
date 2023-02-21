using Microsoft.EntityFrameworkCore;
using PublisherDomain;
using System.Data.Common;

namespace PublisherData
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}