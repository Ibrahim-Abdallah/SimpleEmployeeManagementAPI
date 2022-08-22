using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
    public interface IWrapperRepository
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }

        void Save();
        Task SaveAsync();
    }
}
