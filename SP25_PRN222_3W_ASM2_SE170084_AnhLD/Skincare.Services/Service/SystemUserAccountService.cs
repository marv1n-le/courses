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
    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;
        public SystemUserAccountService()
        {
            _repository = new SystemUserAccountRepository();
        }
        public async Task<SystemUserAccount?> GetUserAccount(string username, string password)
        {
            return await _repository.GetUserAccount(username, password);
        }
    }
}
