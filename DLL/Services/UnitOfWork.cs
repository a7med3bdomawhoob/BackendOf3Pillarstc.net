using BLL.Interfaces;
namespace BLL.Services
{
    public class UnitOfWork:IUnitOfWork
    {
        public IBookRepository bookRepository { get; set; }
        public UnitOfWork(IBookRepository bookrepository)
        {
            bookRepository = bookRepository;
        }
    }
}
