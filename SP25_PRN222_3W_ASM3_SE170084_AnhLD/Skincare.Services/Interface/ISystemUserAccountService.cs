using Skincare.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Services.Interface
{
    public interface ISystemUserAccountService
    {
        Task<SystemUserAccount?> GetUserAccount(string username, string password);
    }
}
