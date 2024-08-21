using System.ComponentModel.DataAnnotations;

namespace myownplatform.DTO
{
    public class loginDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string password { get; set; }
    }
}
