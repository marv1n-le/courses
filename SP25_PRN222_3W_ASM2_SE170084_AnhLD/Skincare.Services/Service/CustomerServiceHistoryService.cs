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
    public class CustomerServiceHistoryService : ICustomerServiceHistoryService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerServiceHistoryService()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<List<CustomerServiceHistory>> GetAllCustomerServiceHistoriesAsync()
        {
            var items = await _unitOfWork.CustomerServiceHistoryRepository.GetAllAsync();
            if (items != null)
            {
                return items;
            }
            return new List<CustomerServiceHistory>();
        }
    }
}
