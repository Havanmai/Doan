using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan1.Common
{
    [Serializable]
    public class AccountLogin
    {
        public long IdAccount { set; get; }
        public string Username { set; get; }
        public string IdGroup { set; get; }
    }
}