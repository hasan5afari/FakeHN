using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.Entities
{
    public partial class Comment
    {
        public int commentid { get; set; }
        public int authorid { get; set; }
        public int postid { get; set; }
        public string body { get; set; }

    }
}
