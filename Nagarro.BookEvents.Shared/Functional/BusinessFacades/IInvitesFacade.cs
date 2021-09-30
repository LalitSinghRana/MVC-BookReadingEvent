using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesFacade : IFacade
    {
        OperationResult<List<EventDTO>> GetInvites(InvitesDTO invitesDTO);
        OperationResult<InvitesDTO> CreateInvites(List<InvitesDTO> listOfInviteDetail);
    }
}
