using DAL.Models;
using DAL.Repositories.Contracts;

namespace DAL.Repositories.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
