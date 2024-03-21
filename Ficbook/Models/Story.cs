using SQLite;

namespace Ficbook.Models;

[Table("Stories")]
public class Story
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    [Indexed]
    public int GenreId { get; set; }
    [Indexed]
    public int ShowId { get; set; }
    [Indexed]
    public int WriterId { get; set; }
}