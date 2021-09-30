using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nagarro.BookEvents.UI
{
    
    public class CommentModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        [Required]
        public string Comment1 { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}"
            , ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string UserName { get; set; }
    }
}
