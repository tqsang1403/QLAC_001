using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models
{
    [Serializable]
    public class UserLoginModel
    {
        public string UserName { get; set; }
        public int UserID { get; set; } 
    }
}