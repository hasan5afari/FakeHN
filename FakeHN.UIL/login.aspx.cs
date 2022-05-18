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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButtonClick(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            string username = loginFormUsername.Value;
            string password = loginFormPassword.Value;

            User user = userManager.isValidUser(username, password);
            if (user != null)
            {
                HttpCookie cook = new HttpCookie("userid");
                cook.Expires = DateTime.Now.AddMinutes(60);
                cook.Value = user.userid.ToString();
                Response.Cookies.Add(cook);
                Response.Redirect("panel.aspx");
            }
            else
            {
                loginResult.InnerText = "Username or Password is wrong .";
            }
        }
    }
}