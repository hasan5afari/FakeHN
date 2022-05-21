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
            try
            {
                // if user didn't log in before, we need to inform him/her .
                if (!Request.Cookies.AllKeys.Contains("userid"))
                {
                    loginResult.InnerText = "You need to log in before using FakeHN";
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("login -> Page_Load() -> " + ex.Message_);
            }
        }

        protected void LoginButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!(loginFormUsername.Value == "" || loginFormPassword.Value == ""))
                {
                    UserManager userManager = new UserManager();
                    string username = loginFormUsername.Value;
                    string password = loginFormPassword.Value;

                    User user = userManager.isValidUser(username, password);
                    if (user != null)
                    {
                        HttpCookie cook = new HttpCookie("userid");
                        cook.Expires = DateTime.Now.AddMonths(3);
                        cook.Value = user.userid.ToString();
                        Response.Cookies.Add(cook);
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        loginResult.InnerText = "Username or Password is wrong .";
                    }
                }
                else
                {
                    loginResult.InnerText = "You have to fill all the fields .";
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("login -> LoginButtonClick() -> " + ex.Message_);
            }
        }

        protected void RegisterButtonClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("register.aspx");
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("login -> RegisterButtonClick() -> " + ex.Message_);
            }
        }
    }
}