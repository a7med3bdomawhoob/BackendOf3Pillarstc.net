using BLL.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
namespace BLL.Services
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private context _context;
        public GenaricRepository(context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return  await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);//update values that it is  value changed
            // context.Entry(entity).State = EntityState.Modified; //update all values
            _context.SaveChanges();
        }
        public void DeleteById(int Id)
        {
            var entity = _context.Set<T>().Find(Id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Entity with ID {Id} not found.");
            }
        }
        public void UpdateById(int id, T obj)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                // Copy values from obj to the existing entity
                _context.Entry(entity).CurrentValues.SetValues(obj);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Entity with ID {id} not found.");
            }
        }
        public void UpdateByRemove(int id, T obj)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                // Delete the existing entity first
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();


                // Create a new entity with the new Id
                _context.Set<T>().Add(obj);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Entity with ID {id} not found.");
            }
        }
    }
}
