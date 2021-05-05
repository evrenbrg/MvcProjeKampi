using MvcProjeKampi.DataAccessLayer.Abstract;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.DataAccessLayer.Concrete.Repositories
{
    public class HeadingRepository : IHeadingDal
    {
        Context c = new Context();
        DbSet<Heading> _object;

        public void Delete(Heading p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(Heading p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Heading> List()
        {
            return _object.ToList();
        }

        public List<Heading> List(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Heading p)
        {
            c.SaveChanges();
        }
    }
}
