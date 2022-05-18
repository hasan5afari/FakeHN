using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.Entities
{
    public partial class Post
    {
        public int postid { get; set; }
        public int authorid { get; set; }
        public int upvotes { get; set; }
        public string body { get; set; }
        public string createdOn { get; set; }
    }
}
