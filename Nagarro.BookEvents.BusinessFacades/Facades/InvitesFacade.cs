using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.BusinessFacades
{
    public class InvitesFacade : FacadeBase, IInvitesFacade
    {
        public InvitesFacade()
            : base(FacadeType.InvitesFacade)
        {

        }

        public OperationResult<InvitesDTO> CreateInvites(List<InvitesDTO> listOfInviteDetail)
        {
            IInvitesBDC eventBDC = (IInvitesBDC)BDCFactory.Instance.Create(BDCType.InvitesBDC);
            return eventBDC.CreateInvites(listOfInviteDetail);
        }

        public OperationResult<List<EventDTO>> GetInvites(InvitesDTO invitesDTO)
        {
            IInvitesBDC eventBDC = (IInvitesBDC)BDCFactory.Instance.Create(BDCType.InvitesBDC);
            return eventBDC.GetInvites(invitesDTO);
        }
    }
}
