using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class InvitesBDC : BDCBase, IInvitesBDC
    {

        private readonly IDACFactory dacFacotry;

        public InvitesBDC()
            : base(BDCType.InvitesBDC)
        {

        }
        public InvitesBDC(IDACFactory dacFacotry)
       : base(BDCType.InvitesBDC)
        {
            this.dacFacotry = dacFacotry;
        }

        public OperationResult<InvitesDTO> CreateInvites(List<InvitesDTO> listOfInviteDetail)
        {
            OperationResult<InvitesDTO> retVal = null;
            try
            {
                IInvitesDAC invitesDAC = (IInvitesDAC)DACFactory.Instance.Create(DACType.InvitesDAC);
                InvitesDTO resultDTO = invitesDAC.CreateInvites(listOfInviteDetail);
                if (resultDTO != null)
                {
                    retVal = OperationResult<InvitesDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<InvitesDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<InvitesDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<InvitesDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<List<EventDTO>> GetInvites(InvitesDTO invitesDTO)
        {
            OperationResult<List<EventDTO>> retVal = null;
            try
            {
                IInvitesDAC invitesDAC = (IInvitesDAC)DACFactory.Instance.Create(DACType.InvitesDAC);
                List<EventDTO> resultDTO = invitesDAC.GetInvites(invitesDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<EventDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<EventDTO>>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<List<EventDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<List<EventDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
