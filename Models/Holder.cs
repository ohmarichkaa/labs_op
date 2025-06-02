using lab6_op.Repositories;

namespace lab6_op.Models
{
    internal class Holder
    {
        public static Repository<Book> BookRepository { get; } = new Repository<Book>(
            new JsonStorage<Book>("books.json"));
    }
}
