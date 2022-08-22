using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Services
{
    public abstract class ServiceBase
    {
        protected IWrapperRepository _wrapperRepository;
        public ServiceBase(IWrapperRepository wrapperRepository)
        {
            _wrapperRepository = wrapperRepository;
        }
    }
}
