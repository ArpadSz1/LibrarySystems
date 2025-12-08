namespace LibrarySystem.App.Dtos
{
    public class ReaderCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int BirthYear { get; set; }
    }
}