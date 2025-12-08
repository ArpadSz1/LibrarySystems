namespace LibrarySystem.UI.Models;


public class Loan
{
    public int LoanId { get; set; }
    public int ReaderId { get; set; }
    public int InventoryNumber { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDeadline { get; set; }
}