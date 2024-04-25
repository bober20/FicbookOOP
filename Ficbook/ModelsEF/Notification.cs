namespace Ficbook.ModelsEF;

public class Notification
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int WriterId { get; set; }
    public DateTime NotificationDate { get; set; }
    public bool IsProblemSolved { get; set; }
}