using Skincare.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Services.Interface
{
    public interface IServiceProviders
    {
        ICustomerServiceHistoryService CustomerServiceHistoryService { get; }
        IServiceProviderInfoService ServiceProviderInfoService { get; }
        ISystemUserAccountService SystemUserAccountService { get; }
    }
}
