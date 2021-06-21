using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetAllRead();
        List<Message> IsDraft();
        Message GetById(int id);
        void MessageAddBL(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
