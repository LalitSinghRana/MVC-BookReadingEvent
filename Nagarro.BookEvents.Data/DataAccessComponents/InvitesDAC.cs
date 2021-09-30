using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.EntityDataModel.EntityModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Data
{
    public class InvitesDAC : DACBase, IInvitesDAC
    {
        public InvitesDAC()
            : base(DACType.InvitesDAC)
        { }

        public InvitesDTO CreateInvites(List<InvitesDTO> listOfInviteDetail)
        {

            using (var context = new BookReadingEventsDBEntities())
            {
                
                foreach (InvitesDTO inviteDetail in listOfInviteDetail)
                {
                    Invite newInvite = new Invite();
                    EntityConverter.FillEntityFromDTO(inviteDetail, newInvite);
                    context.Invites.Add(newInvite);
                } 
                context.SaveChanges();
                return listOfInviteDetail[0];

            }
        }

        public List<EventDTO> GetInvites(InvitesDTO invitesDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                
                List<EventDTO> listOfInvites = null;
                Event eventModel = new Event();
                Invite inviteModel = new Invite();
                var invitesEntityList = context.Invites.Where(i => i.UserId == invitesDTO.UserId).
                    GroupJoin(context.Events,
                    i => i.EventId, e => e.Id, (i, eve) => new
                    {
                        eventDetail = eve
                    });

                if (invitesEntityList != null)
                {
                    listOfInvites = new List<EventDTO>();

                    foreach (var invite in invitesEntityList)
                    {
                        if (invite.eventDetail.ElementAt(0).Type != "Private")
                        {
                            EventDTO eventDTO = new EventDTO();
                            EntityConverter.FillDTOFromEntity(invite.eventDetail.ElementAt(0), eventDTO);
                            listOfInvites.Add(eventDTO);
                        }
                    }

                }

                return listOfInvites;
            }
        }

    }
}
