using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.BusinessLayer.Abstract
{
    public interface ITalentService
    {
        List<Talent> GetTalents();
        void Insert(Talent talent);
        void Update(Talent talent);
        void Delete(Talent talent);
        Talent GetById(int id);
    }
}
