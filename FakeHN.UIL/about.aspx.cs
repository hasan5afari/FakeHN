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
            // Check if user already logged in or not .
            if (Request.Cookies.AllKeys.Contains("userid"))
            {
                // load user
                int userid = Convert.ToInt32(Request.Cookies["userid"].Value);
                UserManager userManager = new UserManager();
                user = userManager.getUser(userid);

                aboutUserINFO.InnerHtml =
                $@"<a href='panel.aspx'>{user.name}  {user.family} ({user.username})</a> <span>&nbsp;</span>";

                Button logoutBtn = new Button();
                logoutBtn.Text = "[ Logout ]";
                logoutBtn.ID = $"logoutButton";
                logoutBtn.Attributes["class"] = "btn bg-transparent";
                logoutBtn.Click += new EventHandler((s, ee) => LogoutButtonClick(s, ee));

                aboutUserINFO.Controls.Add(logoutBtn);
            }
        }

        protected void LogoutButtonClick(object sender, EventArgs e)
        {
            //Check if Cookie exists.
            if (Request.Cookies["userid"] != null)
            {
                HttpCookie nameCookie = Request.Cookies["userid"];
                nameCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(nameCookie);

                Response.Redirect("index.aspx");
            }
        }
    }
}