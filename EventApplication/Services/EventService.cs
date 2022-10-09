using EventApplication.Data;
using EventApplication.Models;

namespace EventApplication.Services
{
    public interface IEventService
    {
        bool RaiseEvent(string name, object content);
        IEnumerable<Event> GetEvents(int fromSequenceNumber, int count);
        IEnumerable<Event> GetAllEvents();
    }
    public class EventService : IEventService
    {
        private readonly IEventStore _eventStore;

        public EventService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public bool RaiseEvent(string name, object content)
        {
            return _eventStore.AddEvent(name, content);
        }

        public IEnumerable<Event> GetEvents(int fromSequenceNumber, int count)
        {
            return _eventStore.GetEvents(fromSequenceNumber, count);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventStore.GetAllEvents();
        }
    }
}
