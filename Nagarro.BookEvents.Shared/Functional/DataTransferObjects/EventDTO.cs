using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEvents.Shared;

namespace Nagarro.BookEvents.Shared
{
    [EntityMapping("Event", MappingType.TotalExplicit)]
    public class EventDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Title")]
        public string Title { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Date")]
        public DateTime Date { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Location")]
        public string Location { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "StartTime")]
        public DateTime StartTime { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DurationInHours")]
        public int DurationInHours { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        public string Description { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "OtherDetails")]
        public string OtherDetails { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "InviteEmails")]
        public string InviteEmails { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "TotalInvites")]
        public int TotalInvites { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Type")]
        public string Type { get; set; }
    }
}
