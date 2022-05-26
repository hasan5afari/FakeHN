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
    public partial class TLPostController : System.Web.UI.UserControl
    {
        public Post post;
        public User currentUser;
        public int i; // Post index ...
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
                    currentUser = userManager.getUser(userid);
                }

                LoadPost();
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("post -> LoadPost() -> " + ex.Message_);
            }
        }

        protected void LoadPost()
        {
            try
            {
                UserManager userManager = new UserManager();
                User user = userManager.getUser(post.authorid);

                // Load post time and date
                PostIcon(ref post);

                // Load post body
                PostBody(ref post);

                // Load post comments and likes
                PostCommentsAndLikes(ref post, ref i);

                // Load post footer
                PostFooter(ref i, post.postid);
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("post -> LoadPost() -> " + ex.Message_);
            }
        }

        private void PostIcon(ref Post post)
        {
            try
            {
                dateContainer.InnerHtml = Utilities.parseDate(post.createdOn).Substring(0, 10);
                timeContainer.InnerHtml = Utilities.parseDate(post.createdOn).Substring(11);
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("post -> PostIcon() -> " + ex.Message_);
            }
        }

        private void PostBody(ref Post post)
        {
            try
            {
                PostManager postManager = new PostManager();
                UserManager userManager = new UserManager();
                User postAuthor = userManager.getUser(post.authorid);
                bool userVoted = postManager.userVoted(post, currentUser);

                postAuthorName.InnerText = postAuthor.name + " " + postAuthor.family;
                postVotes.ID += post.postid;
                upvoteIcon.Attributes["fill"] = (userVoted) ? "orange" : "currentColor";
                upvoteText.Style.Value = $"padding-top: 2px; color: {((userVoted) ? "orange" : "")}";
                upvoteText.InnerText = post.upvotes.ToString();
                postBodyText.InnerText = post.body;
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("post -> PostBody() -> " + ex.Message_);
            }
        }

        private void PostCommentsAndLikes(ref Post post, ref int i)
        {
            try
            {
                CommentManager commentManager = new CommentManager();
                UserManager userManager = new UserManager();
                List<Comment> postComments = commentManager.getPostComments(post.postid);

                commentSectionLink.Attributes["href"] = "#allComments" + post.postid.ToString();
                commentSectionLink.InnerHtml = postComments.Count.ToString() + " Comments";
                commentSectionLink.ID += post.postid;

                // adding comments
                for (int j = 0; j < postComments.Count; j++)
                {
                    User commentAuthor = userManager.getUser(postComments[j].authorid);
                    PostCommentController postComment = (PostCommentController)Page.LoadControl("~/controls/PostCommentController.ascx");
                    postComment.ClientIDMode = ClientIDMode.Static;
                    postComment.cm = postComments[j];
                    allComments.Controls.Add(postComment);
                }

                allComments.ID += post.postid.ToString();
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("post -> PostCommentsAndLikes() -> " + ex.Message_);
            }
        }

        private void PostFooter(ref int i, int postid)
        {
            try
            {
                string comm = linkToCommentBox.Attributes["href"];
                linkToCommentBox.Attributes["href"] = "#commentBox" + i.ToString();
                linkToCommentBox.ID = null;
                commentBox.ID += i.ToString();
                commentInput.ID += post.postid.ToString();
                commentButton.ID += post.postid.ToString();
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("post -> TimeLineFooter() -> " + ex.Message_);
            }
        }
    }
}