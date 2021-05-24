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

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
        
        //public void CategoryAddBll(Category p)
        //{
        //    if(p.CategoryName == "" || p.CategoryStatus==false || p.CategoryName.Length <=2)
        //    {

        //    }
        //    else
        //    {
        //        _categoryDal.Insert(p);
        //    }
        //}
    }
}
