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
    public partial class editUser : System.Web.UI.Page
    {
        private User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Check if user already logged in or not .
                if (!Request.Cookies.AllKeys.Contains("userid"))
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    // load user
                    int userid = Convert.ToInt32(Request.Cookies["userid"].Value);
                    UserManager userManager = new UserManager();
                    user = userManager.getUser(userid);

                    editUserUserINFO.InnerHtml =
                    $@"<a href='panel.aspx'>{user.name}  {user.family} ({user.username})</a> <span>&nbsp;</span>";

                    Button logoutBtn = new Button();
                    logoutBtn.Text = "[ Logout ]";
                    logoutBtn.ID = $"logoutButton";
                    logoutBtn.Attributes["class"] = "btn bg-transparent";
                    logoutBtn.Click += new EventHandler((s, ee) => LogoutButtonClick(s, ee));

                    editUserUserINFO.Controls.Add(logoutBtn);
                }

                if (!IsPostBack)
                {
                    int userid = 0;

                    // Getting post id
                    if (Request.QueryString["UID"] != null && Request.QueryString["UID"] != string.Empty)
                    {
                        userid = Convert.ToInt32(Request.QueryString["UID"]);
                    }

                    UserManager userManager = new UserManager();
                    User editing_user = userManager.getUser(userid);

                    if (user.userid != 1)
                    {
                        Response.Redirect("~/index.aspx");
                    }

                    editFormUsername.Value = editing_user.username;
                    editFormPassword.Value = editing_user.password;
                    editFormName.Value = editing_user.name;
                    editFormFamily.Value = editing_user.family;
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("editUser -> Page_Load() -> " + ex.Message_);
            }
        }

        protected void SaveEditsButtonClick(object sender, EventArgs e)
        {
            try
            {
                UserManager userManager = new UserManager();
                User editing_user = new User();
                editing_user.userid = Convert.ToInt32(Request.QueryString["UID"]);
                editing_user.username = editFormUsername.Value;
                editing_user.password = editFormPassword.Value;
                editing_user.name = editFormName.Value;
                editing_user.family = editFormFamily.Value;

                if (userManager.updateUser(editing_user))
                {
                    Response.Redirect("~/userManagementPanel.aspx");
                }
                else
                {
                    editUserResult.InnerText = "Failed to edit the user !";
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("editUser -> SaveEditsButtonClick() -> " + ex.Message_);
            }
        }

        protected void LogoutButtonClick(object sender, EventArgs e)
        {
            try
            {
                //Check if Cookie exists.
                if (Request.Cookies["userid"] != null)
                {
                    HttpCookie nameCookie = Request.Cookies["userid"];
                    nameCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(nameCookie);

                    Response.Redirect("~/index.aspx");
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("editPost -> LogoutButtonClick() -> " + ex.Message_);
            }
        }
    }
}