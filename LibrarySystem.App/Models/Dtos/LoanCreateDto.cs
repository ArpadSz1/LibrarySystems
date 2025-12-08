using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.App.Dtos
{
    public class LoanCreateDto
    {
        [Required]
        public int ReaderId { get; set; }

        [Required]
        public int InventoryNumber { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public DateTime ReturnDeadline { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LoanDate.Date < DateTime.Today)
            {
                yield return new ValidationResult(
                    "LoanDate cannot be earlier than today.",
                    new[] { nameof(LoanDate) });
            }

            if (ReturnDeadline <= LoanDate)
            {
                yield return new ValidationResult(
                    "ReturnDeadline must be later than the LoanDate.",
                    new[] { nameof(ReturnDeadline) });
            }
        }
    }
}