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
        protected void Page_Load(object sender, EventArgs e)
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

                indexUserINFO.InnerHtml = 
                $@"<a href='panel.aspx'>{user.name}  {user.family} ({user.username})</a> <span>&nbsp;</span>";

                Button logoutBtn = new Button();
                logoutBtn.Text = "[ Logout ]";
                logoutBtn.ID = $"logoutButton";
                logoutBtn.Attributes["class"] = "btn bg-transparent";
                logoutBtn.Click += new EventHandler((s, ee) => LogoutButtonClick(s, ee));

                indexUserINFO.Controls.Add(logoutBtn);
            }

            // update top 3 slider
            LoadTop3();

            // load posts
            LoadPosts();

        }

        protected void LoadTop3()
        {
            PostManager postManager = new PostManager();
            UserManager userManager = new UserManager();
            Post[] posts = postManager.getTop3();

            if (posts.Length >= 3)
            {
                for (int i = 0; i < posts.Length; i++)
                {
                    User user = userManager.getUser(posts[i].authorid);
                    HtmlGenericControl top3Item = new HtmlGenericControl("div");
                    top3Item.ID = "top3" + (i + 1).ToString();
                    top3Item.Attributes["class"] = "carousel-item";
                    if (i == 0)
                    {
                        top3Item.Attributes["class"] += " active";
                    }
                    top3Item.InnerHtml =
                    $@"
                            <!-- TOP3 ITEM -->
                            <div class='carousel-image d-block mx-auto w-50'>
                                <div class='tile-header mt-5 pt-5'>
                                  <svg xmlns = 'http://www.w3.org/2000/svg' width='32' height='32' fill='currentColor' class='bi bi-person-circle' viewBox='0 0 16 16'>
                                    <path d = 'M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z' />
                                    <path fill-rule='evenodd' d='M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z'/>
                                  </svg>
                                  <span id = 'top3{i + 1}FullName' class='username ps-2 h6 text-black'>{user.name + user.family}</span>
                                </div>
                                <div class='tile-body mt-2'>
                                    <p id = 'top3{i + 1}Body'> {posts[i].body} </p>
                                </div>
                            </div>
                            <div class='carousel-caption border-top'>
                                <span class='h5'>TREND #{i + 1}</span>
                            </div>
                    ";
                    top3CarouselContent.Controls.Add(top3Item);
                }
            }
        }

        protected void LoadPosts()
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
                newLi.InnerHtml =
                $@"
                   <div class='row w-100'>
                      <!-- timeline icons -->
                        {TimeLineIcons(ref post)}
                      <!-- body -->
                        {PostBody(ref post, ref user)}
                      <!-- Like and comments -->
                        {PostCommentsAndLikes(ref post, ref i)}
                      <!-- Footer -->
                        {TimeLineFooter(ref i)}
                   </div>
                ";

                timeLineContent.Controls.Add(newLi);
            }

        }
        private string TimeLineIcons(ref Post post)
        {
            return
            $@"
                <div class='col-2 col-md-3'>
                    <div class='timeline-time'>
                        <span class='date'>{Utilities.parseDate(post.createdOn).Substring(0, 10)}</span>
                        <span class='time'>{Utilities.parseDate(post.createdOn).Substring(11)}</span>
                    </div>
                    <div class='timeline-icon'>
                        <a href = 'javascript:;' > &nbsp;</a>
                    </div>
                </div>
            ";
        }

        private string PostBody(ref Post post, ref User user)
        {
            return
            $@"
                <div class='col-10 col-md-8'>
                <div class='timeline-body ms-5 me-3 ps-0 pe-0 me-sm-4 ms-md-1 me-md-5 '>
                    <div class='timeline-header'>
                        <svg xmlns = 'http://www.w3.org/2000/svg' width='32' height='32' fill='currentColor' class='bi bi-person-circle' viewBox='0 0 16 16'>
                        <path d = 'M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z' />
                        <path fill-rule='evenodd' d='M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z'/>
                        </svg>
                    <span class='username ps-2 h6 text-black'>{user.name + ' ' + user.family}</span>
                    <span class='pull-right text-muted'>
                    <div class='row upvote'>
                        <div class='col-1'>
                        <svg id = 'upvoteIcon' xmlns='http://www.w3.org/2000/svg' width='28' height='28' fill='currentColor' class='bi bi-arrow-up-short' viewBox='0 0 16 16'>
                            <path fill-rule='evenodd' d='M8 12a.5.5 0 0 0 .5-.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 .5.5z'/>
                        </svg>
                        </div>
                        <div id = 'upvoteText' class='col' style='padding-top: 2px;'>
                        {post.upvotes}
                        </div>
                    </div>
                    </span>
                </div>
                <div class='timeline-content'>
                    <p>
                    {post.body}
                    </p>
                </div>
            ";
        }

        private string PostCommentsAndLikes(ref Post post, ref int i)
        {
            CommentManager commentManager = new CommentManager();
            UserManager userManager = new UserManager();
            List<Comment> postComments = commentManager.getPostComments(post.postid);

            string result =
            $@"
                <div class='timeline-likes'>
                    <div class='stats-left'>
                        <a id='commentSection{i}Link' href = '#commentSection{i}' class='stats-text text-muted text-decoration-none' data-bs-toggle='collapse'>{postComments.Count} Comments</span>
                        <div id = 'commentSection{i}'class='collapse container-fluid comments-container mt-4'>
            ";

            // adding comments
            for (int j = 0; j < postComments.Count; j++)
            {
                User commentAuthor = userManager.getUser(postComments[j].authorid);
                result +=
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
                                  <span class='h6 text-black'>{commentAuthor.name + " " + commentAuthor.family}</span> <span class='text-muted'>said</span>:
                                </div>
                              </div>
                            </div>
                            <div class='comment-body ps-5'>
                              <p>
                                {postComments[j].body}
                              </p>
                            </div>
                        </div>
                ";
            }

            result +=
            $@"
                        </div>
                    </div>
                    <div class='stats'>
                        <span>&nbsp;</span>
                    </div>
                </div>
            ";

            return result;
        }

        private string TimeLineFooter(ref int i)
        {
            return 
            $@"
                <div class='timeline-footer'>
                    <a href = '#commentBox{i}' class='text-decoration-none m-r-15 text-inverse-lighter' data-bs-toggle='collapse'>
                        <svg xmlns = 'http://www.w3.org/2000/svg' width='16' height='16' fill='currentColor' class='bi bi-chat-left-text' viewBox='0 0 16 16'>
                            <path d = 'M14 1a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H4.414A2 2 0 0 0 3 11.586l-2 2V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12.793a.5.5 0 0 0 .854.353l2.853-2.853A1 1 0 0 1 4.414 12H14a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z' />
                            <path d='M3 3.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zM3 6a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9A.5.5 0 0 1 3 6zm0 2.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5z'/>
                        </svg>
                        Comment
                    </a>
                    <div id='commentBox{i}' class='collapse'>
                        <div class='timeline-comment-box bg-transparent'>
                           <div class='user mt-1 ms-1'>
                                <svg xmlns = 'http://www.w3.org/2000/svg' width='28' height='28' fill='currentColor' class='bi bi-person-circle' viewBox='0 0 16 16'>
                                  <path d = 'M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z' />
                                  <path fill-rule='evenodd' d='M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z'/>
                                </svg>
                            </div>
                            <div class='input'>
                                <form action = '' >
                                    <div class='input-group'>
                                        <input type = 'text' class='form-control rounded-corner' placeholder='Write a comment...'>
                                        <span class='input-group-btn p-l-10'>
                                            <button class='btn btn-primary f-s-12 rounded-corner' type='button'>Comment</button>
                                        </span>
                                    </div>
                                </form>
                            </div>
                         </div>
                     </div>
                </div>
            ";
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