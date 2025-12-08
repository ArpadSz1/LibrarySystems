using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.App.Dtos
{
    public class ReaderCreateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        [Range(1900, int.MaxValue)]
        public int BirthYear { get; set; }
    }
}