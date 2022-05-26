using FakeHN.BLL;
using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeHN.UIL.controls
{
    public partial class PostCommentController : System.Web.UI.UserControl
    {
        public Comment cm;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserManager userManager = new UserManager();
                User user = userManager.getUser(cm.authorid);
                commentAuthor.InnerText = user.name + " " + user.family;
                commentBody.InnerText = cm.body;
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("PostCommentController -> LoadPost() -> " + ex.Message_);
            }
        }
    }
}