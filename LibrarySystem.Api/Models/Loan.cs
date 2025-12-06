using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.App.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [Required]
        [ForeignKey("Reader")]
        public int ReaderId { get; set; }
        public Reader Reader { get; set; } = null!;

        [Required]
        [ForeignKey("Book")]
        public int InventoryNumber { get; set; }
        public Book Book { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Loan), nameof(ValidateLoanDate))]
        public DateTime LoanDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Loan), nameof(ValidateReturnDate))]
        public DateTime ReturnDeadline { get; set; }


        public static ValidationResult? ValidateLoanDate(DateTime date, ValidationContext context)
        {
            if (date.Date < DateTime.Now.Date)
                return new ValidationResult("A kölcsönzés dátuma nem lehet korábbi a mai napnál.");
            return ValidationResult.Success;
        }

        public static ValidationResult? ValidateReturnDate(DateTime date, ValidationContext context)
        {
            var instance = (Loan)context.ObjectInstance;

            if (date.Date <= instance.LoanDate.Date)
                return new ValidationResult("A visszahozási határidő későbbi kell legyen, mint a kölcsönzés dátuma.");

            return ValidationResult.Success;
        }
    }
}
