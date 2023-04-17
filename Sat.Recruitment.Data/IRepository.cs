using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<int> SaveAsync(T entity);
        Task<T> GetAsync(int id);
        Task<T> GetAsync(string email);
    }
}
