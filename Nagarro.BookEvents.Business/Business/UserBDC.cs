using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;
using Nagarro.BookEvents.Validations;

namespace Nagarro.BookEvents.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        private readonly IDACFactory dacFacotry;

        public UserBDC()
            : base(BDCType.UserBDC)
        {

        }

        public UserBDC(IDACFactory dacFacotry)
       : base(BDCType.UserBDC)
        {
            this.dacFacotry = dacFacotry;
        }
        public OperationResult<UserDTO> CreateUser(UserDTO userDTO)
        {
            OperationResult<UserDTO> retVal = null;
            try
            {

                var result = Validator<UserValidation, UserDTO>.Validate(userDTO);

                if (!result.IsValid)
                {
                    retVal = OperationResult<UserDTO>.CreateFailureResult(result.Errors[0].ErrorMessage);
                    return retVal;
                }

                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                UserDTO resultDTO = userDAC.CreateUser(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<UserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<UserDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<UserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<UserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<UserDTO> LoginUser(UserDTO userDTO)
        {
            OperationResult<UserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                UserDTO resultDTO = userDAC.LoginUser(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<UserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<UserDTO>.CreateFailureResult(Constant.LoginFailureresult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<UserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<UserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
