using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test2.Contract;
using Test2.Data;

namespace Test2.Repository
{
    public class GenricRepostory<T> : IgenricRepostory<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        
        public GenricRepostory( ApplicationDbContext context )
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
                }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
         //   var entity = await GetAsync(id);
           
                _context.Set<T>().Remove(entity);
           
            await _context.SaveChangesAsync();
            
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
                
                }

        public async Task<T?> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GettAll()
        {
           return await _context.Set<T>().ToListAsync(); 
        }

        public async Task UpdateAsync(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

        }

    }
}
