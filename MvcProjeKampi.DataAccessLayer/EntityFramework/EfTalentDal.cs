using MvcProjeKampi.DataAccessLayer.Abstract;
using MvcProjeKampi.DataAccessLayer.Concrete.Repositories;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.DataAccessLayer.EntityFramework
{
    public class EfTalentDal:GenericRepository<Talent>,ITalentDal
    {
    }
}
