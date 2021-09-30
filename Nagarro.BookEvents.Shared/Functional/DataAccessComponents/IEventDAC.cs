using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IEventDAC : IDataAccessComponent
    {
        EventDTO GetEventDetails(EventDTO eventDTO);
        List<EventDTO> GetEvents(EventDTO eventDTO);
        List<EventDTO> GetPastEvents();
        List<EventDTO> GetFutureEvents();
        EventDTO CreateEvent(EventDTO eventDTO);
        EventDTO EditEvent(EventDTO eventDTO);
        bool DeleteEvent(EventDTO eventDTO);
        List<EventDTO> Events(EventDTO eventDTO);
    }
}
