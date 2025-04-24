using Skincare.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Services.Service
{
    public class ServiceProviders : IServiceProviders 
    {
        private IServiceProviderInfoService _serviceProviderInfoService;
        private ICustomerServiceHistoryService _customerServiceHistoryService;
        private ISystemUserAccountService _systemUserAccountService;

        public ServiceProviders() { }

        public IServiceProviderInfoService ServiceProviderInfoService
        {
            get
            {
                return _serviceProviderInfoService ??= new ServiceProviderInfoService();
            }
        }

        public ICustomerServiceHistoryService CustomerServiceHistoryService
        {
            get
            {
                return _customerServiceHistoryService ??= new CustomerServiceHistoryService();
            }
        }

        public ISystemUserAccountService SystemUserAccountService
        {
            get
            {
                return _systemUserAccountService ??= new SystemUserAccountService();
            }
        }
    }
}
