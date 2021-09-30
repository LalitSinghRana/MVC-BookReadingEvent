﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IInvitesBDC : IBusinessDomainComponent
    {
        OperationResult<List<EventDTO>> GetInvites(InvitesDTO invitesDTO);
        OperationResult<InvitesDTO> CreateInvites(List<InvitesDTO> listOfInviteDetail);
    }
}
