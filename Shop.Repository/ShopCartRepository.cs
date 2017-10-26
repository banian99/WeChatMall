using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Model;
using Shop.IRepository;
namespace Shop.Repository
{
  public  class ShopCartRepository:BaseRepository<ShopCart>,IShopCartRepository
    {
    }
}
