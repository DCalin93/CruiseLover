using CruiseLover.DB;
using System.Collections.Generic;

namespace CruiseLover.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}
