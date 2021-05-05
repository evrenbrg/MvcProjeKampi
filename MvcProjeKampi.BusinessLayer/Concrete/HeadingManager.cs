using MvcProjeKampi.BusinessLayer.Abstract;
using MvcProjeKampi.DataAccessLayer.Abstract;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        
        
        public List<Heading> GetList()
        {
            return _headingDal.List();
        }
    }
}
