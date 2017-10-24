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
    public class ProductService : BaseService<product>, IProductService
    {
        public ProductService(IBaseRepository<product> baseReposity) : base(baseReposity)
        {
        }
    }
}
