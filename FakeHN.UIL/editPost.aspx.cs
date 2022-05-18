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
            // load post
            int postid = Convert.ToInt32(Request.Cookies["postid"].Value);
            PostManager postManager = new PostManager();
            post = postManager.getPost(postid);

            if (!IsPostBack)
            {
                editPostTextArea.Value = post.body;
            }

            // load user
            int userid = Convert.ToInt32(Request.Cookies["userid"].Value);
            UserManager userManager = new UserManager();
            user = userManager.getUser(userid);

            editUserINFO.InnerHtml = $"<a href='panel.aspx'>{user.name}  {user.family} ({ user.username})</a>";
        }

        protected void SaveEditsButtonClick(object sender, EventArgs e)
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
    }
}