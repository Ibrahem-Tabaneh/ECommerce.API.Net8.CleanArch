using Ecom4.Core.IRepository;
using Ecom4.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom4.Infrastructure.Repository
{
    public class GenricRepository<T> : IGenricRepository<T> where T : class
    {
        public  AppDbContext context;

        public GenricRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           var list= await context.Set<T>().AsNoTracking().ToListAsync();
            return list;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity=await context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
