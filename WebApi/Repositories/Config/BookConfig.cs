using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Price = 150 },
                new Book { Id = 2, Title = "The Great ", Price = 102 },
                new Book { Id = 3, Title = "The", Price = 105 }
            );
        }
    }
}
