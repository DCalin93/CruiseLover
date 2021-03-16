using CruiseLover.Core.Interfaces;
using CruiseLover.DB;
using System.Collections.Generic;
using System.Linq;

namespace CruiseLover.Core
{
    public class UserService : IUserService
    {
        private CLDbContext _context;

        public UserService(CLDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList(); ;
        }
    }
}
