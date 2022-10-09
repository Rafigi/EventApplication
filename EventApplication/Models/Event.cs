namespace EventApplication.Models;

public class Event
{
    public int SequenceNumber { get; set; }
    public string Name { get; set; }
    public DateTimeOffset OccuredAt { get; set; }
    public object Content { get; set; }
}