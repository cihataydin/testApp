using TestApi.Data;
using TestApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestApi.UOW
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly TutorialDBContext _dbContext;
        public EFUnitOfWork(TutorialDBContext dbContext)
        {

            if (dbContext == null)
                throw new Exception("db context null");

            _dbContext = dbContext;

        }

        public IEFRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new EFRepository<T>(_dbContext);
        }

        public void Dispose()
        {
            try
            {
                _dbContext.Dispose();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}