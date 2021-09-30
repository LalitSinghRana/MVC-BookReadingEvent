using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Business
{
    public class CommentsBDC : BDCBase, ICommentsBDC
    {
        private readonly IDACFactory dacFacotry;

        public CommentsBDC()
            : base(BDCType.CommentsBDC)
        {

        }
        public CommentsBDC(IDACFactory dacFacotry)
       : base(BDCType.CommentsBDC)
        {
            this.dacFacotry = dacFacotry;
        }

        public OperationResult<CommentsDTO> CreateComments(CommentsDTO commentsDTO)
        {
            OperationResult<CommentsDTO> retVal = null;
            try
            {
                ICommentsDAC commentDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
                CommentsDTO resultDTO = commentDAC.CreateComments(commentsDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<CommentsDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<CommentsDTO>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<CommentsDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<CommentsDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<bool> DeleteComment(CommentsDTO commentsDTO)
        {
            OperationResult<bool> retVal = null;
            try
            {
                ICommentsDAC commentDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
                bool resultDTO = commentDAC.DeleteComment(commentsDTO);
                if (resultDTO)
                {
                    retVal = OperationResult<bool>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<bool>.CreateFailureResult(Constant.UserFailureResult);
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

        public OperationResult<List<CommentsDTO>> GetComments(CommentsDTO commentsDTO)
        {
            OperationResult<List<CommentsDTO>> retVal = null;
            try
            {
                ICommentsDAC commentDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
                List<CommentsDTO> resultDTO = commentDAC.GetComments(commentsDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<CommentsDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<CommentsDTO>>.CreateFailureResult(Constant.UserFailureResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<List<CommentsDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<List<CommentsDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
