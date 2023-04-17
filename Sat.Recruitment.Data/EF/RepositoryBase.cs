using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.EF
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly UserContext _context;
        private readonly DbSet<T> _dbSet;

        protected RepositoryBase(UserContext userContext)
        {
            _context = userContext ?? throw new ArgumentNullException(nameof(userContext));
            _dbSet = _context.Set<T>();
        }


        public async Task<T> GetAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                Exception exception = new(e.Message);
                throw exception;
            }
        }

        public async Task<T> GetAsync(string email)
        {
            try
            {
                return await _dbSet.FindAsync(email);
            }
            catch (Exception e)
            {
                Exception exception = new(e.Message);
                throw exception;
            }
        }

        public async Task<int> SaveAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Exception exception = new(e.Message);
                throw exception;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            //Place here all resources to destroy
            _context?.Dispose();
        }
    }
}
