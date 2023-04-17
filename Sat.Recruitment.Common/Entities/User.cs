
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Common.Entities
{
    public class User
    {
        [JsonIgnore]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        public decimal? Money { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }
        
    }
}
