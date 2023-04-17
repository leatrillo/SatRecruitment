using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Common.Entities;
using Sat.Recruitment.Data.EF.Contract;
using System.Threading.Tasks;
using System;

namespace Sat.Recruitment.Data.EF.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(UserContext userContext) : base(userContext)
        {

        }
        
        public async Task<User> GetByEmail(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            
        }

        public async Task<int> SaveUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                int newUserId = user.UserId;
                return newUserId;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            

        }
    }
}
