using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IUserDAC : IDataAccessComponent
    {
        UserDTO CreateUser(UserDTO userDTO);
        UserDTO LoginUser(UserDTO userDTO);
    }
}
