using DAL.Models;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> table;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return table.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T? t = await table.FindAsync(id);
            return t;
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }
    }
}
