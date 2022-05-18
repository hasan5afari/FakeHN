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
    public partial class createPost : System.Web.UI.Page
    {
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            // load user
            int userid = Convert.ToInt32(Request.Cookies["userid"].Value);
            UserManager userManager = new UserManager();
            user = userManager.getUser(userid);

            editUserINFO.InnerHtml = $"<a href='panel.aspx'>{user.name}  {user.family} ({ user.username})</a>";
        }

        protected void CreatePostButtonClick(object sender, EventArgs e)
        {
            Post post = new Post();
            DateTime now = DateTime.Now;

            post.body = createPostTextArea.Value.Replace('\'','\"');
            post.authorid = user.userid;
            post.upvotes = 0;
            post.createdOn = $"{now.Month}/{now.Day}/{now.Year} {now.Hour}:{now.Minute}:{now.Second}";

            PostManager postManager = new PostManager();
            if (postManager.savePost(post))
            {
                Response.Redirect("panel.aspx");
            }
            else
            {
                createPostResult.InnerText = "Failed to edit the post !";
            }
        }
    }
}