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
    public class CustomerServiceHistoryService : ICustomerServiceHistoryService
    {
        private readonly CustomerServiceHistoryRepository _repository;
        public CustomerServiceHistoryService()
        {
            _repository = new CustomerServiceHistoryRepository();
        }
        public async Task<List<CustomerServiceHistory>> GetAllCustomerServiceHistoriesAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
