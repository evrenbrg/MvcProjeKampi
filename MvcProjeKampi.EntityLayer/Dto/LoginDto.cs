using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampi.EntityLayer.Dto
{
    public class LoginDto
    {

        public string AdminUserName{ get; set; }
     
        public string AdminPassword { get; set; }

        public string AdminRole { get; set; }
    }
}
