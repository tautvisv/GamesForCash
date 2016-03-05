using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public object Login(string name, string password)
        {
            return 0;
        }
    }
}
