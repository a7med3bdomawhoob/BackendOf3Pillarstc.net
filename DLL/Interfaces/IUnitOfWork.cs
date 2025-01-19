namespace BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IBookRepository _bookRepository { get; set; }

    }
}
