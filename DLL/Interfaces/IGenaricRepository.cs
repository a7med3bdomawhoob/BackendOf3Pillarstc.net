namespace BLL.Interfaces
{
    public interface IGenaricRepository<T>
    {
        Task <IEnumerable<T>> GetAll(  );
        Task<T>  GetById(int id);
        Task  Add(T entity);
        public void Delete(T entity);
        void Update(T entity);
        void UpdateById(int id, T entity);
        void UpdateByRemove(int id, T entity);
        
        public void DeleteById(int Id);
    }
}
