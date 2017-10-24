using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using Shop.IRepository;
using Shop.IService;
namespace Shop.Service
{
    public class ProductSortService : BaseService<ProductSort>, IProductSortService
    {
        public ProductSortService(IBaseRepository<ProductSort> baseReposity) : base(baseReposity)
        {
        }
    }
}
