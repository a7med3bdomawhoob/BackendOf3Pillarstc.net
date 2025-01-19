using BLL.Interfaces;
namespace BLL.Services
{
    public class UnitOfWork:IUnitOfWork
    {
        public IBookRepository _bookRepository { get; set; }
        public UnitOfWork(IBookRepository bookrepository)
        {
            _bookRepository = bookrepository;
        }
    }
}
