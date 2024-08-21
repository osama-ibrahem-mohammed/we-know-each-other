using System.ComponentModel.DataAnnotations;

namespace myownplatform.DTO
{
    public class registerDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string password { get; set; }
    }
}
