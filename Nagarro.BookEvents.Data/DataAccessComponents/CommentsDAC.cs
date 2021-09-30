using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.EntityDataModel.EntityModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Data
{
    public class CommentsDAC : DACBase, ICommentsDAC
    {
        public CommentsDAC()
            : base(DACType.CommentsDAC)
        {

        }

        public CommentsDTO CreateComments(CommentsDTO commentsDTO)
        {
            CommentsDTO retVal = null; ;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    Comment newComment = new Comment();
                    EntityConverter.FillEntityFromDTO(commentsDTO, newComment);
                    System.Diagnostics.Debug.WriteLine(newComment.Comment1);
                    context.Comments.Add(newComment);
                    context.SaveChanges();
                    retVal = commentsDTO;

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;

        }

        public bool DeleteComment(CommentsDTO commentsDTO)
        {
            bool result = false;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    var deleteComment = context.Comments.SingleOrDefault(c => c.Id == commentsDTO.Id);
                    result = false;
                    if (deleteComment != null)
                    {
                        context.Comments.Remove(deleteComment);
                        context.SaveChanges();
                        result = true;
                    }
  
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;
       
        }

        public List<CommentsDTO> GetComments(CommentsDTO commentsDTO)
        {

            List<CommentsDTO> result = null;
            try
            {
                using (var context = new BookReadingEventsDBEntities())
                {
                    List<CommentsDTO> listOfComments = null;
                    var commentsEntityList = context.Comments.Where(c => c.EventId == commentsDTO.EventId).ToList();

                    if (commentsEntityList != null)
                    {
                        listOfComments = new List<CommentsDTO>();

                        foreach (var comment in commentsEntityList)
                        {
                            CommentsDTO commentDTO = new CommentsDTO();
                            EntityConverter.FillDTOFromEntity(comment, commentDTO);
                            listOfComments.Add(commentDTO);
                        }

                    }

                    result = listOfComments;

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return result;
        }

    }
}
