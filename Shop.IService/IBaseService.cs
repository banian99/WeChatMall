using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IService
{
    public interface IBaseService<TEntity> where TEntity:class,new()
    {
        bool Add(TEntity tEntity);
        bool Modify(TEntity tEntity);
        bool Remove(TEntity tEntity);
        //获取单个实体 
        TEntity GetEntity(Func<TEntity, bool> whereLambda);
        //获取实体列表
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);
        //分页查询
        IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, TType>> orderBylambda, Expression<Func<TEntity, bool>> whereLambda);

    }
}
