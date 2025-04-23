using Skincare.Repositories.Models;
using Skincare.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skincare.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        CustomerServiceHistoryRepository CustomerServiceHistoryRepository { get; }
        ServiceProviderInfoRepository ServiceProviderInfoRepository { get; }
        SystemUserAccountRepository SystemUserAccountRepository { get; }
        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SP25_PRN222_W3_PRJ_G1_SkinCareBookingServiceContext _context;
        private CustomerServiceHistoryRepository _customerServiceHistoryRepository;
        private ServiceProviderInfoRepository _serviceProviderInfoRepository;
        private SystemUserAccountRepository _systemUserAccountRepository;

        public UnitOfWork() => _context = new SP25_PRN222_W3_PRJ_G1_SkinCareBookingServiceContext();

        public CustomerServiceHistoryRepository CustomerServiceHistoryRepository
        {
            get
            {
                return _customerServiceHistoryRepository ??= new CustomerServiceHistoryRepository(_context);
            }
        }

        public ServiceProviderInfoRepository ServiceProviderInfoRepository
        {
            get
            {
                return _serviceProviderInfoRepository ??= new ServiceProviderInfoRepository(_context);
            }
        }

        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get
            {
                return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context);
            }
        }

        public void Dispose() => _context.Dispose();

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    //Log exception handling message
                    result = -1;
                    transaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    //Log exception handling message
                    result = -1;
                    await transaction.RollbackAsync();
                }
            }

            return result;
        }
    }
}
