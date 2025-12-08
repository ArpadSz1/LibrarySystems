namespace LibrarySystem.UI.Models;


public class Book
{
    public int InventoryNumber { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public int YearPublished { get; set; }
}