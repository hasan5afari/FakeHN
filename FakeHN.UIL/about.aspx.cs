using FakeHN.BLL;
using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeHN.UIL
{
    public partial class About : System.Web.UI.Page
    {
        private User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies.Count > 0)
            {
                try
                {
                    // load user
                    int userid = Convert.ToInt32(Request.Cookies["userid"].Value);
                    UserManager userManager = new UserManager();
                    user = userManager.getUser(userid);

                    aboutUserINFO.InnerHtml = $"<a href='panel.aspx'>{user.name}  {user.family} ({ user.username})</a>";
                }
                catch (NullReferenceException ex) { }
            }
        }
    }
}