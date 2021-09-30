using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesDAC : IDataAccessComponent
    {
        List<EventDTO> GetInvites(InvitesDTO inviteDTO);
        InvitesDTO CreateInvites(List<InvitesDTO> listOfInviteDetail);
    }
}
