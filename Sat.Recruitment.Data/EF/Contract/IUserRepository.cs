using Sat.Recruitment.Common.Entities;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.EF.Contract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<int> SaveUserAsync(User user);
    }
}
