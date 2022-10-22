namespace LibraryService.Models
{

    public class Author
    {
        public string Name { get; set; }
        public string Lang { get; set; }

        public override string ToString() => $"{Name} ({Lang})";
    }
}