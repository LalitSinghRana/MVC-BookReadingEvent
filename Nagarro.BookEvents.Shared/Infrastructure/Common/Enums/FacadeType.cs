using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("Nagarro.BookEvents.BusinessFacades.dll", "Nagarro.BookEvents.BusinessFacades.UserFacade")]
        UserFacade = 1,

        [QualifiedTypeName("Nagarro.BookEvents.BusinessFacades.dll", "Nagarro.BookEvents.BusinessFacades.EventFacade")]
        EventFacade = 2,

        [QualifiedTypeName("Nagarro.BookEvents.BusinessFacades.dll", "Nagarro.BookEvents.BusinessFacades.InvitesFacade")]
        InvitesFacade = 3,

        [QualifiedTypeName("Nagarro.BookEvents.BusinessFacades.dll", "Nagarro.BookEvents.BusinessFacades.CommentsFacade")]
        CommentsFacade = 4


    }
}
