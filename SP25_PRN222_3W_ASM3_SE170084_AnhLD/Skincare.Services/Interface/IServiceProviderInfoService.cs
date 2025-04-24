using Skincare.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Services.Interface
{
     public interface IServiceProviderInfoService
    {
        Task<List<ServiceProviderInfo>> GetAllServiceProvidersAsync();
        Task<ServiceProviderInfo> GetServiceProviderByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<int> CreateAsync(ServiceProviderInfo serviceProviderInfo);
        Task<int> UpdateAsync(ServiceProviderInfo serviceProviderInfo);
    }
}
