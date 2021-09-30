using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.EntityDataModel.EntityModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Nagarro.BookEvents.UI.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //admin hard-coded
            UserDTO adminUser = new UserDTO();
            adminUser.Email = "myadmin@bookevents.com";
            adminUser.Password = "Lalitrana12-B";
            adminUser.FullName = "adminGuy";
            adminUser.Role = "admin";
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<UserDTO> result = userFacade.CreateUser(adminUser);
            
            return View();
        }
      
        public ActionResult UpcomingEvent()
        {
            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<List<EventDTO>> result = eventFacade.GetFutureEvents();

            if (result.IsValid() && result.Data.Count != 0)
            {
                List<EventDTO> eventsDTO = result.Data;
                List<EventModel> eventsModel = new List<EventModel>();

                foreach (EventDTO eventDTO in eventsDTO)
                {
                    EventModel eventModel = new EventModel();
                    EntityConverter.FillEntityFromDTO(eventDTO, eventModel);
                    eventsModel.Add(eventModel);
                }

                return View(eventsModel);
            }
            return View();
        }

   

        public ActionResult PastEvent()
        {
      
            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<List<EventDTO>> result = eventFacade.GetPastEvents();

            if (result.IsValid() && result.Data.Count != 0)
            {
                
                List<EventDTO> eventsDTO = result.Data;
                List<EventModel> eventsModel = new List<EventModel>();

                foreach (EventDTO eventDTO in eventsDTO)
                {
                    EventModel eventModel = new EventModel();
                    EntityConverter.FillEntityFromDTO(eventDTO, eventModel);
                    eventsModel.Add(eventModel);
                }

                return View(eventsModel);
            }
           
            return View();
        }

      

        public ActionResult Details(EventModel model)
        {
            if (model.Id != 0)
            {
                EventDTO eventDetail = new EventDTO();
                eventDetail.Id = model.Id;

                IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
                OperationResult<EventDTO> result = eventFacade.GetEventDetails(eventDetail);

                if (result.ResultType == OperationResultType.Failure)
                {
                    ModelState.AddModelError("", result.Message);
                    return View();
                }

                if (result.IsValid())
                {
                    EntityConverter.FillEntityFromDTO(result.Data, model);
                }
                return View(model);
            }

            return View();
        }

    }
}