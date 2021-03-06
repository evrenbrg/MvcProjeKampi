using MvcProjeKampi.EntityLayer.Dto;
using MvcProjeKampi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void Register(string adminMail, string password);
        bool Login(LoginDto loginDto);
        bool WriterLogin(WriterLoginDto writerLoginDto);
        void WriterRegister(string mail, string password);
    }
}
