using SQLite;

namespace Ficbook.ModelsEF;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int WriterId { get; set; }
    public int StoryId { get; set; }
    //navigation properties
    // public Writer Writer { get; set; }
    // public Story Story { get; set; }
}