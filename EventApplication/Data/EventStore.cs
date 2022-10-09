using EventApplication.Models;

namespace EventApplication.Data;

public interface IEventStore
{
    bool AddEvent(string name, object content);
    IEnumerable<Event> GetEvents(int fromSequenceNumber, int count);
    IEnumerable<Event> GetAllEvents();
}
public class EventStore : IEventStore
{
    private readonly List<Event> events = new List<Event>();

    public bool AddEvent(string name, object content)
    {
        Event newEvent = CreateEvent(name, content);
        events.Add(newEvent);

        return isEventAdded(newEvent);

    }
    public IEnumerable<Event> GetEvents(int fromSequenceNumber, int count) =>
        events
            .Where(e => e.SequenceNumber >= fromSequenceNumber)
            .Take(count)
            .ToList();

    public IEnumerable<Event> GetAllEvents() => events;

    private bool isEventAdded(Event newEvent) => events.Exists(p => p == newEvent);

    private Event CreateEvent(string name, object content)
    {
        int nextSequence = events.Count + 1;
        if (events.Any(e => e.SequenceNumber == nextSequence))
            throw new AggregateException(
                $"Could not add the event, with sequenceNumber {nextSequence}, because it already exist!");

        return new Event()
        {
            SequenceNumber = nextSequence,
            Name = name,
            Content = content,
            OccuredAt = DateTime.Now
        };
    }

}