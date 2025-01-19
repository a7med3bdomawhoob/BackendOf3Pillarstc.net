using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace BLL.Services
{
    public class BookRepository : IBookRepository
    {
        private context _context;

        public BookRepository(context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.books
                .Include(b => b.Department)
                .Include(b => b.Job) 
                .ToListAsync(); // Executes the query and returns a list
        }
        public async Task<IQueryable<Book>> SearchForBooks(string? bookName, DateTime? birthDate)
        {
            // Start with the base query
            /*var query = _context.books.AsQueryable();  //Instead IEnumberable To Less Load In Memory Filter*/
            var query = _context.books.Include(d=>d.Department).Include(j=>j.Job).AsQueryable();  //Instead IEnumberable To Less Load In Memory Filter
            // Filter by book name (if provided)
            if (!string.IsNullOrWhiteSpace(bookName))
            {
                query = query.Where(b => EF.Functions.Like(b.FullName, $"%{bookName}%"));
            }
            // Filter by birth date (if provided)
            if (birthDate.HasValue)
            {
                query = query.Where(b => b.DateOfBirth.Date == birthDate.Value.Date);
            }
            return await Task.FromResult(query);
        }
    }
}
