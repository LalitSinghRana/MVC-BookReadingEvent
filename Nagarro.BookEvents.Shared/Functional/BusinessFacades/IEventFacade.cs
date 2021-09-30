using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IEventFacade : IFacade
    {
        OperationResult<EventDTO> GetEventDetails(EventDTO eventDTO);
        OperationResult<List<EventDTO>> GetEvents(EventDTO eventDTO);
        OperationResult<List<EventDTO>> GetPastEvents();
        OperationResult<List<EventDTO>> GetFutureEvents();
        OperationResult<EventDTO> CreateEvent(EventDTO eventDTO);
        OperationResult<EventDTO> EditEvent(EventDTO eventDTO);
        OperationResult<bool> DeleteEvent(EventDTO eventDTO);
        OperationResult<List<EventDTO>> Events(EventDTO eventDTO);
    }
}
