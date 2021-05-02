using MvcProjeKampi.BusinessLayer.Abstract;
using MvcProjeKampi.DataAccessLayer.Abstract;
using MvcProjeKampi.DataAccessLayer.Concrete.Repositories;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }
}
