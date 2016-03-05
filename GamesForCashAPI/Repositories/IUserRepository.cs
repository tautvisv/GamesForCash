using Models;

namespace Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        object Login(string name, string password);
    }
}