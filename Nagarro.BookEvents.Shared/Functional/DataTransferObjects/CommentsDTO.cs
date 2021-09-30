using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Shared
{
    [EntityMapping("Comments", MappingType.TotalExplicit)]
    public class CommentsDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
        public int EventId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Comment1")]
        public string Comment1 { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Date")]
        public DateTime Date { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserName")]
        public string UserName { get; set; }

    }
}
