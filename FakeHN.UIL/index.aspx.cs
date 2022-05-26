using FakeHN.BLL;
using FakeHN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FakeHN.UIL
{
    public partial class FakeHN : System.Web.UI.Page
    {
        private User user;
        private static int userid;

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
                    userid = Convert.ToInt32(Request.Cookies["userid"].Value);
                    UserManager userManager = new UserManager();
                    user = userManager.getUser(userid);

                    indexUserINFO.InnerHtml =
                    $@"<a href='panel.aspx'>{user.name}  {user.family} ({user.username})</a> <span>&nbsp;</span>";

                    Button logoutBtn = new Button();
                    logoutBtn.Text = "[ Logout ]";
                    logoutBtn.ID = $"logoutButton";
                    logoutBtn.Attributes["class"] = "btn bg-transparent";
                    logoutBtn.Click += new EventHandler((s, ee) => LogoutButtonClick(s, ee));

                    indexUserINFO.Controls.Add(logoutBtn);
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("index -> Page_Load() -> " + ex.Message_);
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
                exceptionManager.saveException("index -> LogoutButtonClick() -> " + ex.Message_);
            }
        }

        [WebMethod]
        public static void UpdateVotes(int postid, bool increase)
        {
            try
            {
                PostManager postManager = new PostManager();
                Post post = postManager.getPost(postid);
                if (increase)
                {
                    post.upvotes += 1;
                    postManager.addVote(postid, userid);
                    postManager.updatePost(post);
                }
                else
                {
                    if (post.upvotes > 0)
                    {
                        post.upvotes -= 1;
                        postManager.removeVote(postid, userid);
                        postManager.updatePost(post);
                    }

                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("index -> UpdateVotes() -> " + ex.Message_);
            }
        }

        [WebMethod]
        public static string UpdateComments(int postid, string comment)
        {
            string result = "";
            try
            {
                UserManager userManager = new UserManager();
                PostManager postManager = new PostManager();
                CommentManager commentManager = new CommentManager();

                User commentAuther = userManager.getUser(userid);
                Post post = postManager.getPost(postid);
                Comment newComment = new Comment();
                newComment.authorid = userid;
                newComment.postid = postid;
                newComment.body = comment;

                if (commentManager.addComment(newComment))
                {
                    result =
                    $@"
                        <div class='comment w-100'>
                            <div class='comment-header mt-2 mx-1 mx-md-4'>
                                <div class='row w-100 mb-2'>
                                <div class='col-auto pe-1'>
                                    <svg xmlns = 'http://www.w3.org/2000/svg' width='24' height='24' fill='currentColor' class='bi bi-person-circle' viewBox='0 0 16 16'>
                                    <path d = 'M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z' />
                                    <path fill-rule='evenodd' d='M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z'/>
                                    </svg>
                                </div>
                                <div class='col ps-0' style='padding-top: 2px;'>
                                    <span class='h6 text-black'>{commentAuther.name + " " + commentAuther.family}</span> <span class='text-muted'>said</span>:
                                </div>
                                </div>
                            </div>
                            <div class='comment-body ps-5'>
                                <p>
                                {newComment.body}
                                </p>
                            </div>
                        </div>
                    ";
                }
                else
                {
                    result = $@"Failed to create a new comment !";
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("index -> UpdateComments() -> " + ex.Message_);
            }

            return result;
        }
    }
}