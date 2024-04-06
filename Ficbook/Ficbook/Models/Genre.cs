using SQLite;
namespace Ficbook.Models;

[Table("Genres")]
public class Genre
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Name { get; set; }
    public int AgeLimit { get; set; }
}