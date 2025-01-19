using DAL.Entities;
namespace BLL.Interfaces
{
    public interface IBookRepository
    {
       public Task <IEnumerable<Book>> GetAllBooks();
        public  Task<IQueryable<Book>> SearchForBooks(string? bookName, DateTime? birthDate);
    }
}
