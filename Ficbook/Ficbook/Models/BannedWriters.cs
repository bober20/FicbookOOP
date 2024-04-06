using SQLite;

namespace Ficbook.Models;

[Table("BannedWriters")]
public class BannedWriters
{
    [PrimaryKey, AutoIncrement, Indexed]
    public int Id { get; set; }
    
    [Indexed]
    public int WriterId { get; set; }
}