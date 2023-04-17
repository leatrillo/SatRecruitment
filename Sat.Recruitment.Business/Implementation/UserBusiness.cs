using Sat.Recruitment.Business.Contract;
using Sat.Recruitment.Common.DTO;
using Sat.Recruitment.Common.Entities;
using Sat.Recruitment.Common.Helpper;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Data.EF.Contract;
using Sat.Recruitment.Common.Enums;

namespace Sat.Recruitment.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly ILogger<UserBusiness> _logger;
        private readonly IUserRepository _repository;

        public UserBusiness(ILogger<UserBusiness> logger, IUserRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// create user method
        /// </summary>
        /// <param name="user"></param>
        /// <returns>status code</returns>
        public async Task<UserOutput> CreateUser(User user)
        {
            try
            {
                //email Validation
                UserValidation.IsEmailValid(user.Email);

                //check if the user is already registered
                User usr = await _repository.GetByEmail(user.Email);

                if (usr != null)
                {
                    throw new ArgumentException("You have alredy registered");
                }

                //user type check and gift assignment
                switch (user.UserTypeId)
                {
                    case (int)UserTypes.Normal:
                        if (user.Money > 100)
                        {
                            var percentage = Convert.ToDecimal(0.12);
                            var gift = user.Money * percentage;
                            user.Money += gift;
                        }
                        if (user.Money < 100 && user.Money > 10)
                        {

                            var percentage = Convert.ToDecimal(0.8);
                            var gift = user.Money * percentage;
                            user.Money += gift;

                        }
                        break;

                    case (int)UserTypes.SuperUser:
                        if (user.Money > 100)
                        {
                            var percentage = Convert.ToDecimal(0.20);
                            var gift = user.Money * percentage;
                            user.Money += gift;
                        }
                        break;

                    case (int)UserTypes.Premium:
                        if (user.Money > 100)
                        {
                            var gift = user.Money * 2;
                            user.Money += gift;
                        }
                        break;

                    default:
                        throw new ArgumentException("User type is incorrect, try 1 for normal user, 2 for super user and 3 for Premium user");
                }


                int userId = await _repository.SaveUserAsync(user);

                return new UserOutput
                {
                    UserId = userId,
                    Status = "User Created"
                };

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }

        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUser(int userId)
        {
            try
            {
                return await _repository.GetAsync(userId);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
