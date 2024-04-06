using SQLite;

namespace Ficbook.Models;

[Table("Comments")]
public class Comment
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Content { get; set; }
    [Indexed]
    public int WriterId { get; set; }
    [Indexed]
    public int StoryId { get; set; }
}