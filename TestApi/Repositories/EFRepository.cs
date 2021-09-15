using TestApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestApi.Repositories
{
    public class EFRepository<TEntity> : IEFRepository<TEntity>
                where TEntity : BaseEntity
    {
        private TutorialDBContext _context;
        private DbSet<TEntity> _dbset;

        public EFRepository(TutorialDBContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {

            if (filter == null) return _dbset.AsQueryable();

            return _dbset.Where(filter);

        }

        public void Remove(TEntity entity)
        {

            //entity.IsDeleted = true;

            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}