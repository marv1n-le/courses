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
    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly UnitOfWork _unitOfWork;
        public SystemUserAccountService()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<SystemUserAccount?> GetUserAccount(string username, string password)
        {
            return await _unitOfWork.SystemUserAccountRepository.GetUserAccount(username, password);
        }
    }
}
