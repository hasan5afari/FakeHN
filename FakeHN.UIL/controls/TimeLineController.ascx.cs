using FakeHN.BLL;
using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FakeHN.UIL.controls
{
    public partial class TimeLineController : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load TimeLine Posts
            LoadPosts();
        }

        protected void LoadPosts()
        {
            try
            {
                PostManager postManager = new PostManager();
                UserManager userManager = new UserManager();
                List<Post> allPosts = postManager.getAllPosts();

                for (int i = 0; i < allPosts.Count; i++)
                {
                    User user = userManager.getUser(allPosts[i].authorid);
                    Post post = allPosts[i];

                    HtmlGenericControl newLi = new HtmlGenericControl("li");
                    newLi.ID = "timeLineItem" + i.ToString() + "-" + allPosts[i].postid;
                    newLi.Attributes["class"] = "timeline-item";

                    TLPostController tlPost = (TLPostController)Page.LoadControl("~/controls/TLPostController.ascx");
                    tlPost.ClientIDMode = ClientIDMode.Static;
                    tlPost.post = allPosts[i];
                    tlPost.i = i;
                    newLi.Controls.Add(tlPost);

                    timeLineContent.Controls.Add(newLi);
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("index -> LoadPosts() -> " + ex.Message_);
            }
        }
    }
}