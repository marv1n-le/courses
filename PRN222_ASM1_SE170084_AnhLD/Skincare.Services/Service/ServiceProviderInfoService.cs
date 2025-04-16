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
    }
}
