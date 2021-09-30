using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.EntityDataModel.EntityModel;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Data
{
    public class EventDAC : DACBase, IEventDAC
    {
        public EventDAC()
            : base(DACType.EventDAC)
        {}

       
        public List<EventDTO> Events(EventDTO eventDTO)
        {
            List<EventDTO> listOfEvents = null;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
             
                    var eventsEntityList = context.Events.OrderByDescending(e => e.Date).ToList();

                    if (eventsEntityList != null)
                    {
                        listOfEvents = new List<EventDTO>();
                        foreach (Event levent in eventsEntityList)
                        {
                            EventDTO eveDTO = new EventDTO();
                            EntityConverter.FillDTOFromEntity(levent, eveDTO);
                            listOfEvents.Add(eveDTO);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }


            return listOfEvents;
           
        }

        public EventDTO GetEventDetails(EventDTO eventDTO)
        {
            EventDTO result = eventDTO;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    
                    var eventDetail = context.Events.Where(e => e.Id == eventDTO.Id).SingleOrDefault();

                    if (eventDetail != null)
                    {
                        EntityConverter.FillDTOFromEntity(eventDetail, eventDTO);
                    }

                    result = eventDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;
        }



        public List<EventDTO> GetFutureEvents()
        {
            List<EventDTO> result = null;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    
                    List<EventDTO> listOfEvents = null;
                    var eventsEntityList = context.Events.OrderByDescending(e => e.Date).Where(e => e.Date > DateTime.Now).ToList();

                    if (eventsEntityList != null)
                    {
                        listOfEvents = new List<EventDTO>();
                        foreach (Event levent in eventsEntityList)
                        {
                            if (levent.Type != "Private")
                            {
                                EventDTO eveDTO = new EventDTO();
                                EntityConverter.FillDTOFromEntity(levent, eveDTO);
                                listOfEvents.Add(eveDTO);
                            }
                        }

                    }

                    result = listOfEvents;

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;
    
        }



        public List<EventDTO> GetPastEvents()
        {

            List<EventDTO> result = null;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                 
                    
        
                    List<EventDTO> listOfEvents = null;
                    var eventsEntityList = context.Events.OrderByDescending(e => e.Date).Where(e => e.Date < DateTime.Now).ToList();
                    System.Diagnostics.Debug.WriteLine(eventsEntityList);
                    if (eventsEntityList != null)
                    {
                        
                        listOfEvents = new List<EventDTO>();
                        foreach (Event levent in eventsEntityList)
                        {
                            if (levent.Type != "Private")
                            {
                                EventDTO eveDTO = new EventDTO();
                                EntityConverter.FillDTOFromEntity(levent, eveDTO);
                                listOfEvents.Add(eveDTO);
                            }
                        }

                    }

                    
                    result = listOfEvents;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;

        }
        
    
        public List<EventDTO> GetEvents(EventDTO eventDTO)
        {
            List<EventDTO> result = null;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    
                    List<EventDTO> listOfEvents = null;
                    var eventsEntityList = context.Events.OrderByDescending(e => e.Date).Where(e => e.UserId == eventDTO.UserId).ToList();

                    if (eventsEntityList != null)
                    {
                        listOfEvents = new List<EventDTO>();
                        foreach (Event levent in eventsEntityList)
                        {
                            EventDTO eveDTO = new EventDTO();
                            EntityConverter.FillDTOFromEntity(levent, eveDTO);
                            listOfEvents.Add(eveDTO);
                        }

                    }

                    result = listOfEvents;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;

            
        }

        private List<string> ConvertInviteEmails(EventDTO eventDTO)
        {
            List<string> emails = null;
            if (eventDTO.InviteEmails != null)
            {
                string[] result = eventDTO.InviteEmails.Split(',');
                emails = new List<string>();
                foreach (string res in result)
                {
                    emails.Add(res.Trim());
                }
            }
            
            return emails;
        }

     
        public EventDTO CreateEvent(EventDTO eventDTO)
        {
            List<string> inviteEmails = ConvertInviteEmails(eventDTO);
            EventDTO result = null;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    
                    Event newEvent = new Event();
                    EntityConverter.FillEntityFromDTO(eventDTO, newEvent);

                    var eventModel = context.Events.Add(newEvent);
                    context.SaveChanges();

                    int countOfInvites = 0;
                    if (inviteEmails != null && newEvent.Type != "Private")
                    {
                        foreach (string email in inviteEmails)
                        {
                            var user = context.Users.Where(u => u.Email == email).SingleOrDefault();
                            if (user != null)
                            {
                                Invite inviteDetail = new Invite();
                                inviteDetail.EventId = newEvent.Id;
                                inviteDetail.UserId = user.Id;
                                context.Invites.Add(inviteDetail);
                                context.SaveChanges();
                                countOfInvites++;
                            }
                        }
                    }

                    eventModel.TotalInvites = countOfInvites;
                    context.SaveChanges();
                    EntityConverter.FillDTOFromEntity(eventModel, eventDTO);
                    result = eventDTO;

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;

            
        }


        public EventDTO EditEvent(EventDTO eventDTO)
        {
            List<string> inviteEmails = ConvertInviteEmails(eventDTO);
            EventDTO result = null;

            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    
                    Event editEvent = context.Events.SingleOrDefault(e => e.Id == eventDTO.Id);
                    EntityConverter.FillEntityFromDTO(eventDTO, editEvent);
                    context.SaveChanges();

                    int countOfInvites = 0;
                    if (inviteEmails != null && editEvent.Type != "Private")
                    {
                        foreach (string email in inviteEmails)
                        {
                            var user = context.Users.Where(u => u.Email == email).SingleOrDefault();

                            if (user != null)
                            {
                                var invite = context.Invites
                                .SingleOrDefault(i => i.EventId == editEvent.Id && i.UserId == user.Id);

                                if (invite == null)
                                {
                                    Invite inviteDetail = new Invite();
                                    inviteDetail.EventId = editEvent.Id;
                                    inviteDetail.UserId = user.Id;
                                    context.Invites.Add(inviteDetail);
                                    context.SaveChanges();
                                }

                                countOfInvites++;
                            }
                        }
                    }

                    editEvent.TotalInvites = countOfInvites;
                    context.SaveChanges();
                    EntityConverter.FillDTOFromEntity(editEvent, eventDTO);
                    result = eventDTO;

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;

            
        }

        public bool DeleteEvent(EventDTO eventDTO)
        {
            bool result = false;

            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    
                    var deleteEvent = context.Events
                        .SingleOrDefault(e => e.Id == eventDTO.Id);
                    result = false;
                    if (deleteEvent != null)
                    {
                        // Deleting Invites
                        var deleteInvites = context.Invites.Where(i => i.EventId == eventDTO.Id).ToList();
                        foreach (var invite in deleteInvites)
                        {
                            context.Invites.Remove(invite);
                            context.SaveChanges();
                        }

                        // Deleting Comments
                        var deleteComments = context.Comments.Where(c => c.EventId == eventDTO.Id).ToList();
                        foreach (var comment in deleteComments)
                        {
                            context.Comments.Remove(comment);
                            context.SaveChanges();
                        }

                        // Deleting Event
                        context.Events.Remove(deleteEvent);
                        context.SaveChanges();
                        result = true;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;
           
        }
    }
}
