using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.BusinessFacades
{
    public class EventFacade : FacadeBase, IEventFacade
    {
        public EventFacade()
            : base(FacadeType.EventFacade)
        {

        }
        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.CreateEvent(eventDTO);
        }

        public OperationResult<bool> DeleteEvent(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.DeleteEvent(eventDTO);
        }

        public OperationResult<EventDTO> EditEvent(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.EditEvent(eventDTO);
        }

        public OperationResult<EventDTO> GetEventDetails(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetEventDetails(eventDTO);
        }

        public OperationResult<List<EventDTO>> GetEvents(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetEvents(eventDTO);
        }

        public OperationResult<List<EventDTO>> GetPastEvents()
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetPastEvents();
        }

        public OperationResult<List<EventDTO>> GetFutureEvents()
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetFutureEvents();
        }

        public OperationResult<List<EventDTO>> Events(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.Events(eventDTO);
        }
    }
}
