using SQLite;

namespace Ficbook.Models;

[System.ComponentModel.DataAnnotations.Schema.Table("Characters")]
public class Character
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Sex CharacterSex { get; set; }
    public bool AliveStatus { get; set; }
    [Indexed]
    public int ShowId { get; set; }

    public enum Sex
    {
        Man,
        Woman,
    }
}