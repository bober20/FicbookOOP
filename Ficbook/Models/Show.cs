using SQLite;
using System.Collections.ObjectModel;

namespace Ficbook.Models;

[Table("Shows")]
public class Show
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfRelease { get; set; }
    public bool FinishStatus { get; set; }
    public string MoreInformation { get; set; }
}