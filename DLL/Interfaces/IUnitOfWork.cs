namespace BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IBookRepository bookRepository { get; set; }

    }
}
