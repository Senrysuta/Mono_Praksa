namespace Library.Model
{
    internal interface IBookRest
    {
        int AuthorId { get; set; }
        int BookId { get; set; }
        string ISBN { get; set; }
        string OriginalLanguage { get; set; }
        int PublishYear { get; set; }
        string Title { get; set; }
    }
}