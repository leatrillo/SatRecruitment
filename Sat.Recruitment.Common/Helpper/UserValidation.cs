using System;
using System.Text.RegularExpressions;

namespace Sat.Recruitment.Common.Helpper
{
    public class UserValidation
    {
        protected UserValidation() { }
        
        public static void IsEmailValid(string email)
        {
            //regex rule
            string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            bool isValidEmail = Regex.IsMatch(email, emailRegex);

            if (!isValidEmail)
            {
                throw new ArgumentException("Invalid email");
            }
        }

    }
}
