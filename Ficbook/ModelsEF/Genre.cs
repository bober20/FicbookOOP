using SQLite;
namespace Ficbook.ModelsEF;


public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AgeLimit { get; set; }
}