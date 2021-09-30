using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    [EntityMapping("User", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }
        [EntityPropertyMapping(MappingDirectionType.Both, "FullName")]//There is no entity like Sample that exists
        public string FullName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        public string Email { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
        public string Password { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Role")]
        public string Role { get; set; }
    }
}
