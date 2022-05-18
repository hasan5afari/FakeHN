using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.Entities
{
    public partial class User
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string family { get; set; }

    }
}
