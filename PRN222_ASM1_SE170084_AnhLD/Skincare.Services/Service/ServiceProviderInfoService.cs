using Skincare.Repositories.Models;
using Skincare.Repositories.Repository;
using Skincare.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Services.Service
{
    public class ServiceProviderInfoService : IServiceProviderInfoService
    {
        private readonly ServiceProviderInfoRepository _repository;

        public ServiceProviderInfoService()
        {
            _repository = new ServiceProviderInfoRepository();
        }

        public async Task<List<ServiceProviderInfo>> GetAllServiceProvidersAsync()
        {
            return await _repository.GetAllServiceProvidersAsync();
        }

        public async Task<ServiceProviderInfo> GetServiceProviderByIdAsync(int id)
        {
            return await _repository.GetServiceProviderByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var items = await _repository.GetServiceProviderByIdAsync(id);
            if (items != null)
            {
                var result = await _repository.RemoveAsync(items);
                return result;
            }
            return false;
        }

        public async Task<int> CreateAsync(ServiceProviderInfo serviceProviderInfo)
        {
            var result = await _repository.CreateAsync(serviceProviderInfo);
            return result;
        }
        
        public async Task<int> UpdateAsync(ServiceProviderInfo serviceProviderInfo)
        {
            var result = await _repository.UpdateAsync(serviceProviderInfo);
            return result;
        }
    }
}
