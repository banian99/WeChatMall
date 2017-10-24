using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.IService;
using Shop.Model;
using Shop.IRepository;
using System.Linq.Expressions;

namespace Shop.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        public  IBaseRepository<TEntity> _baseRepository;
        //有一个无参数的构造函数
        public BaseService(IBaseRepository<TEntity> baseReposity)
        {
           this._baseRepository = baseReposity;
        }
        public bool Add(TEntity tEntity)
        {
            _baseRepository.Insert(tEntity);
            return _baseRepository.SavaChanges();
        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntities(whereLambda);
        }

        public IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, TType>> orderBylambda, Expression<Func<TEntity, bool>> whereLambda)
        {
            return _baseRepository.QueryEntitiesByPage(pageSize, pageIndex, isAsc, orderBylambda, whereLambda);
        }

        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntity(whereLambda);
        }

        public bool Modify(TEntity tEntity)
        {
            _baseRepository.Update(tEntity);
            return _baseRepository.SavaChanges();
        }

        public bool Remove(TEntity tEntity)
        {
            _baseRepository.Delete(tEntity);
            return _baseRepository.SavaChanges();
        }
    }
}
