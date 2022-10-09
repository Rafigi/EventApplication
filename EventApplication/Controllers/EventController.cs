using EventApplication.Models;
using EventApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EventApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : Controller
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }


    /// <summary>
    /// Publish an Pizza Event
    /// </summary>
    /// <param name="e"></param>
    [HttpPost("OrderPizzaEvent")]
    public IActionResult RaisePizzaEvent(Pizza pizza)
    {

        bool isEventRaised = _eventService.RaiseEvent("PizzaEvent", pizza);

        if (isEventRaised)
            return Ok("Event is Raised");

        return BadRequest("Could not raise the Event");
    }



    /// <summary>
    /// Publish an Event
    /// </summary>
    /// <param name="e"></param>
    [HttpPost("raiseEvent")]
    public IActionResult RaiseEvent(Event e)
    {
        bool isEventRaised = _eventService.RaiseEvent(e.Name, e.Content);

        if (isEventRaised)
            return Ok("Event is Raised");

        return BadRequest("Could not raise the Event");
    }

    /// <summary>
    /// Get all the events, specified by startIndex and how many
    /// </summary>
    /// <param name="fromSequenceNumber">Start index for event</param>
    /// <param name="count">How many event should be returned</param>
    /// <returns></returns>
    [HttpGet("listEvent")]
    public IEnumerable<Event> ListEvents(int fromSequenceNumber, int count)
    {
        return _eventService.GetEvents(fromSequenceNumber, count);
    }

    /// <summary>
    /// Get all events
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public IEnumerable<Event> GetAllEvents()
    {
        return _eventService.GetAllEvents();
    }
}