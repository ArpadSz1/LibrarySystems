using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.App.Models
{
    public class Reader
    {
        [Key]
        public int ReaderId { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string Address { get; set; } = string.Empty;

        [Range(1900, int.MaxValue, ErrorMessage = "Birthyear can't be less then 1900")]
        public int BirthYear { get; set; }
    }
}
