using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface ICommentsBDC : IBusinessDomainComponent
    {
        OperationResult<List<CommentsDTO>> GetComments(CommentsDTO commentsDTO);
        OperationResult<CommentsDTO> CreateComments(CommentsDTO commentsDTO);
        OperationResult<bool> DeleteComment(CommentsDTO commentsDTO);
    }
}
