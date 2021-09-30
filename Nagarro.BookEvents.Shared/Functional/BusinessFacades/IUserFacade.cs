using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IUserFacade : IFacade
    {
        OperationResult<UserDTO> CreateUser(UserDTO userDTO);
        OperationResult<UserDTO> LoginUser(UserDTO userDTO);
    }
}
