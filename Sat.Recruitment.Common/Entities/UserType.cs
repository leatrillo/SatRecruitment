using System.Collections.Generic;

namespace Sat.Recruitment.Common.Entities
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
