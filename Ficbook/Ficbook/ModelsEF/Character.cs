using SQLite;

namespace Ficbook.ModelsEF;


public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Sex CharacterSex { get; set; }
    public bool AliveStatus { get; set; }
    public int ShowId { get; set; }
    //navigation properties
    public Show Show { get; set; }

    public enum Sex
    {
        Man,
        Woman,
    }
}