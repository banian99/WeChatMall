using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.IRepository
{
    //数据访问接口层  IDAL
    //设置通用接口  增删改查：泛型约束，必须是引用类型 还必须是具有无参的构造函数
    public interface IBaseRepository<TEntity> where TEntity:class,new()
    {
        //1:插入数据的时候，插入的某一个实体对象，所以必须有一个参数
        void Insert(TEntity Tentity);
        void Delete(TEntity Tentity);
        void Update(TEntity Tentity);
        bool SavaChanges();
        //查询有多种查询方法：查询单个的，带有条件查询的，分页的等等
        TEntity QueryEntity(Func<TEntity, bool> whereLambda);
        //查询实体集合
        IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda);
        //分页查询
        IEnumerable<TEntity> QueryEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<TEntity, TType>> orderBylambda, Expression<Func<TEntity, bool>> whereLambda);

    }
}
