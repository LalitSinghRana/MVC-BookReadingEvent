using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface ICommentsDAC : IDataAccessComponent
    {
        List<CommentsDTO> GetComments(CommentsDTO commentsDTO);
        CommentsDTO CreateComments(CommentsDTO commentsDTO);
        bool DeleteComment(CommentsDTO commentsDTO);
    }
}
