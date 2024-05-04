using SQLite;

namespace Ficbook.ModelsEF;


public class Story
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int GenreId { get; set; }
    public int ShowId { get; set; }
    public int WriterId { get; set; }
    public string ImageSource { get; set; }
    //navigation properties
    // public Writer Writer { get; set; }
    // public Genre Genre { get; set; }
    // public Show Show { get; set; }
    // public List<Comment> Comments { get; set; }
}