﻿using Microsoft.EntityFrameworkCore;
using Skincare.Repositories.Base;
using Skincare.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Repositories.Repository
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() : base()
        {
        }

        public async Task<SystemUserAccount?> GetUserAccount(string userName, string password)
        {
            var userAccount = await _context.SystemUserAccounts
                .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);
            return userAccount;
        }
    }
}
