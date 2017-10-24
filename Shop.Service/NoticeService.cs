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
    class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(IBaseRepository<Notice> baseReposity) : base(baseReposity)
        {
        }
    }
}
