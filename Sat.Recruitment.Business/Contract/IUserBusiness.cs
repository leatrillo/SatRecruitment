using Sat.Recruitment.Common.DTO;
using Sat.Recruitment.Common.Entities;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business.Contract
{
    public interface IUserBusiness
    {
        Task<UserOutput> CreateUser(User user);
        Task<User> GetUser(int userId);
    }
}
