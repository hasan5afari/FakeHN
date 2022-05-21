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
    public partial class edit : System.Web.UI.Page
    {
        private Post post;
        private User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // load post
                int postid = Convert.ToInt32(Request.Cookies["postid"].Value);
                PostManager postManager = new PostManager();
                post = postManager.getPost(postid);

                if (!IsPostBack)
                {
                    editPostTextArea.Value = post.body;
                }

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

                    editPostUserINFO.InnerHtml =
                    $@"<a href='panel.aspx'>{user.name}  {user.family} ({user.username})</a> <span>&nbsp;</span>";

                    Button logoutBtn = new Button();
                    logoutBtn.Text = "[ Logout ]";
                    logoutBtn.ID = $"logoutButton";
                    logoutBtn.Attributes["class"] = "btn bg-transparent";
                    logoutBtn.Click += new EventHandler((s, ee) => LogoutButtonClick(s, ee));

                    editPostUserINFO.Controls.Add(logoutBtn);
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("editPost -> Page_Load() -> " + ex.Message_);
            }
        }

        protected void SaveEditsButtonClick(object sender, EventArgs e)
        {
            try
            {
                PostManager postManager = new PostManager();
                post.body = editPostTextArea.Value;
                if (postManager.updatePost(post))
                {
                    Response.Redirect("panel.aspx");
                }
                else
                {
                    editPostResult.InnerText = "Failed to edit the post !";
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("editPost -> SaveEditsButtonClick() -> " + ex.Message_);
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

                    Response.Redirect("index.aspx");
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