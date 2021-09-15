using TestApi.Data;
using TestApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.UOW
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IEFRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}