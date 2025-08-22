using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
    }
}
