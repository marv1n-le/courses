using Skincare.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;

        public ServiceProviderInfoService()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<List<ServiceProviderInfo>> GetAllServiceProvidersAsync()
        {
            var items = await _unitOfWork.ServiceProviderInfoRepository.GetAllAsync();
            if (items != null)
            {
                return items;
            }
            return new List<ServiceProviderInfo>();
        }

        public async Task<ServiceProviderInfo> GetServiceProviderByIdAsync(int id)
        {
            var item = await _unitOfWork.ServiceProviderInfoRepository.GetServiceProviderByIdAsync(id);
            if (item != null)
            {
                return item;
            }
            return new ServiceProviderInfo();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            //var items = await _repository.GetServiceProviderByIdAsync(id);
            //if (items != null)
            //{
            //    var result = await _repository.RemoveAsync(items);
            //    return result;
            //}
            //return false;

            var result = await _unitOfWork.ServiceProviderInfoRepository.RemoveAsync(await GetServiceProviderByIdAsync(id));

            return result;
        }

        public async Task<int> CreateAsync(ServiceProviderInfo serviceProviderInfo)
        {
            var result = await _unitOfWork.ServiceProviderInfoRepository.CreateAsync(serviceProviderInfo);
            return result;
        }
        
        public async Task<int> UpdateAsync(ServiceProviderInfo serviceProviderInfo)
        {
            var result = await _unitOfWork.ServiceProviderInfoRepository.UpdateAsync(serviceProviderInfo);
            return result;
        }

        public async Task<List<ServiceProviderInfo>> Search(string providerName, string providerType, string serviceUsed)
        {
            var items = await _unitOfWork.ServiceProviderInfoRepository.Search(providerName, providerType, serviceUsed);
            return items;
        }
    }
}
