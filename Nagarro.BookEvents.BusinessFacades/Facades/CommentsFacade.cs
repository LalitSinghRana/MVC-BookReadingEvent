using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.BusinessFacades
{
    public class CommentsFacade : FacadeBase, ICommentsFacade
    {
        public CommentsFacade()
            : base(FacadeType.CommentsFacade)
        {

        }

        public OperationResult<CommentsDTO> CreateComments(CommentsDTO commentsDTO)
        {
            ICommentsBDC commentBDC = (ICommentsBDC)BDCFactory.Instance.Create(BDCType.CommentsBDC);
            return commentBDC.CreateComments(commentsDTO);
        }

        public OperationResult<bool> DeleteComment(CommentsDTO commentsDTO)
        {
            ICommentsBDC commentBDC = (ICommentsBDC)BDCFactory.Instance.Create(BDCType.CommentsBDC);
            return commentBDC.DeleteComment(commentsDTO);
        }

        public OperationResult<List<CommentsDTO>> GetComments(CommentsDTO commentsDTO)
        {
            ICommentsBDC commentBDC = (ICommentsBDC)BDCFactory.Instance.Create(BDCType.CommentsBDC);
            return commentBDC.GetComments(commentsDTO);
        }

    }
}
