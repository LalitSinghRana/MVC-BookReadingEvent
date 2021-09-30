using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.Validations;

namespace Nagarro.BookEvents.Business
{
    public class EventBDC : BDCBase, IEventBDC
    {
        private readonly IDACFactory dacFacotry;

        public EventBDC()
            : base(BDCType.EventBDC)
        {

        }
        public EventBDC(IDACFactory dacFacotry)
       : base(BDCType.EventBDC)
        {
            this.dacFacotry = dacFacotry;
        }
        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            OperationResult<EventDTO> retVal = null;
            try
            {

                var result = Validator<EventValidation, EventDTO>.Validate(eventDTO);
                if (!result.IsValid)
                {
                    retVal = OperationResult<EventDTO>.CreateFailureResult(result.Errors[0].ErrorMessage);
                    return retVal;
                }

                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                EventDTO resultDTO = eventDAC.CreateEvent(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<EventDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<EventDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<EventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<EventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<bool> DeleteEvent(EventDTO eventDTO)
        {
            OperationResult<bool> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                bool resultDTO = eventDAC.DeleteEvent(eventDTO);
                if (resultDTO)
                {
                    retVal = OperationResult<bool>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<bool>.CreateFailureResult(Constant.EventFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<EventDTO> EditEvent(EventDTO eventDTO)
        {
            OperationResult<EventDTO> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                EventDTO resultDTO = eventDAC.EditEvent(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<EventDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<EventDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<EventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<EventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<EventDTO> GetEventDetails(EventDTO eventDTO)
        {
            OperationResult<EventDTO> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                EventDTO resultDTO = eventDAC.GetEventDetails(eventDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<EventDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<EventDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<EventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<EventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<List<EventDTO>> GetEvents(EventDTO eventDTO)
        {
            OperationResult<List<EventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<EventDTO> resultDTO = eventDAC.GetEvents(eventDTO);
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

        public OperationResult<List<EventDTO>> GetPastEvents()
        {
            OperationResult<List<EventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<EventDTO> resultDTO = eventDAC.GetPastEvents();
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

        public OperationResult<List<EventDTO>> GetFutureEvents()
        {
            OperationResult<List<EventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<EventDTO> resultDTO = eventDAC.GetFutureEvents();
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

        public OperationResult<List<EventDTO>> Events(EventDTO eventDTO)
        {
            OperationResult<List<EventDTO>> retVal = null;
            try
            {
                IEventDAC eventDAC = (IEventDAC)DACFactory.Instance.Create(DACType.EventDAC);
                List<EventDTO> resultDTO = eventDAC.Events(eventDTO);
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
