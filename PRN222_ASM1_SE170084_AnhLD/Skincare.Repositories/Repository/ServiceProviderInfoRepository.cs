using Microsoft.EntityFrameworkCore;
using Skincare.Repositories.Base;
using Skincare.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Repositories.Repository
{
    public class ServiceProviderInfoRepository : GenericRepository<ServiceProviderInfo>
    {
        public ServiceProviderInfoRepository() : base()
        {
        }

        public async Task<List<ServiceProviderInfo>> GetAllServiceProvidersAsync()
        {
            var items = await _context.ServiceProviderInfos
                .Include(sp => sp.CustomerServiceHistories)
                .ToListAsync();
            return items;
        }

        public async Task<ServiceProviderInfo?> GetServiceProviderByIdAsync(int id)
        {
            var item = await _context.ServiceProviderInfos
                .Include(sp => sp.CustomerServiceHistories)
                .FirstOrDefaultAsync(sp => sp.ProviderId == id);
            return item;
        }

        public async Task<List<ServiceProviderInfo>> Search(string providerName, string providerType, string serviceUsed)
        {
            var items = await _context.ServiceProviderInfos
                .Include(sp => sp.CustomerServiceHistories)
                .Where(sp => (string.IsNullOrEmpty(providerName) || sp.ProviderName.Contains(providerName)) &&
                             (string.IsNullOrEmpty(providerType) || sp.ServiceType.Contains(providerType)) &&
                             (string.IsNullOrEmpty(serviceUsed) || sp.CustomerServiceHistories.Any(csh => csh.ServiceUsed.Contains(serviceUsed))))
                .ToListAsync();
            return items;
        }
    }
}
