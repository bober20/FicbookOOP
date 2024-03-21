using System.Collections.ObjectModel;
using SQLite;

namespace Ficbook.Models;

[Table("Writers")]
public class Writer
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime DateOfRegistration { get; set; }
    public string MorePersonalInfo { get; set; }
}