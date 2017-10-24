using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shop.IRepository;
using Shop.Model;
using System.Data.Entity;
namespace Shop.Repository
{
    //DAL层
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        //该类必须要有一个无参数的构造函数，必须通过上下文对象来获取实体集中的数据
        //需要每一个地方都实例化一个上下文对象，可以利用工厂模式
        private readonly WeShop _dbContext = DbContextFactory.GenInstance();//获取上下文对象
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository()
        {
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Delete(TEntity Tentity)
        {
            _dbSet.Attach(Tentity);
            _dbSet.Remove(Tentity);
        }

        public void Insert(TEntity Tentity)
        {
            _dbSet.Add(Tentity);
        }

        public IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, TType>> orderBylambda, Expression<Func<TEntity, bool>> whereLambda)
        {
            var result = _dbSet.Where(whereLambda);
            result = isAsc ? result.OrderBy(orderBylambda) : result.OrderByDescending(orderBylambda);
            result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return result.ToList();
        }

        public TEntity QueryEntity(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.FirstOrDefault(whereLambda);
        }

        public bool SavaChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public void Update(TEntity Tentity)
        {
            _dbSet.Attach(Tentity);
            _dbContext.Entry(Tentity).State = EntityState.Modified;//修改实体状态
        }
    }
}
