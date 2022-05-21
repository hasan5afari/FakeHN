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
    public partial class userManagementPanel : System.Web.UI.Page
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

                    panelUserINFO.InnerHtml =
                    $@"<a href='panel.aspx'>{user.name}  {user.family} ({user.username})</a> <span>&nbsp;</span>";

                    Button logoutBtn = new Button();
                    logoutBtn.Text = "[ Logout ]";
                    logoutBtn.ID = $"logoutButton";
                    logoutBtn.Attributes["class"] = "btn bg-transparent";
                    logoutBtn.Click += new EventHandler((s, ee) => LogoutButtonClick(s, ee));

                    panelUserINFO.Controls.Add(logoutBtn);
                }

                // Load users
                LoadUsers();
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("userManagementPanel -> Page_Load() -> " + ex.Message_);
            }
        }

        protected void LoadUsers()
        {
            try
            {
                UserManager userManager = new UserManager();
                List<User> users = userManager.getAllUsers();

                // Create a TableHeaderRow.
                TableHeaderRow headerRow = new TableHeaderRow();

                string[] values = { "#", "Username", "Password", "Name", "Family", "Edit", "Remove" };
                for (int i = 0; i < 7; i++)
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    cell.Text = values[i];
                    headerRow.Cells.Add(cell);
                }

                panelContent.Controls.Add(headerRow);

                if (users.Count > 0)
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell userNumber = new TableCell();
                        TableCell username = new TableCell();
                        TableCell password = new TableCell();
                        TableCell name = new TableCell();
                        TableCell family = new TableCell();
                        TableCell edit = new TableCell();
                        TableCell remove = new TableCell();

                        Button editButton = new Button();
                        Button removeButton = new Button();

                        editButton.Text = "Edit";
                        editButton.ID = $"editUser{users[i].userid}";
                        editButton.Attributes["class"] = "btn btn-primary";
                        editButton.Click += new EventHandler((s, e) => EditUserClick(s, e));
                        editButton.CommandArgument = users[i].userid.ToString();

                        removeButton.Text = "Remove";
                        removeButton.ID = $"removeUser{users[i].userid}";
                        removeButton.Attributes["class"] = "btn btn-primary";
                        removeButton.Click += new EventHandler((s, e) => RemoveUserClick(s, e));
                        removeButton.CommandArgument = users[i].userid.ToString();

                        userNumber.Text = $"{i + 1}";
                        username.Text = users[i].username.Trim();
                        password.Text = users[i].password.Trim();
                        name.Text = users[i].name.Trim();
                        family.Text = users[i].family.Trim();
                        edit.Controls.Add(editButton);
                        remove.Controls.Add(removeButton);

                        row.Cells.Add(userNumber);
                        row.Cells.Add(username);
                        row.Cells.Add(password);
                        row.Cells.Add(name);
                        row.Cells.Add(family);
                        row.Cells.Add(edit);
                        row.Cells.Add(remove);

                        panelContent.Controls.Add(row);
                    }
                }
                else
                {
                    panelUserManagementResult.InnerText = "There is no user to show .";
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("userManagementPanel -> LoadUsers() -> " + ex.Message_);
            }
        }

        protected void EditUserClick(object sender, EventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(((Button)sender).CommandArgument);

                HttpCookie cook = new HttpCookie("editing_user");
                cook.Expires = DateTime.Now.AddMinutes(5);
                cook.Value = userid.ToString();
                Response.Cookies.Add(cook);
                Response.Redirect("editUser.aspx");
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("userManagementPanel -> EditUserClick() -> " + ex.Message_);
            }
        }

        protected void RemoveUserClick(object sender, EventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(((Button)sender).CommandArgument);
                PostManager postManager = new PostManager();
                CommentManager commentManager = new CommentManager();

                // remove all the user votes
                postManager.removeUserVotes(userid);

                // remove posts
                List<Post> posts = postManager.getUserPosts(userid);
                for (int i = 0; i < posts.Count; i++)
                {
                    Post post = posts[i];

                    // remove post comments

                    if (commentManager.removePostComments(post.postid))
                    {
                        postManager.removePost(post.postid);
                    }
                }

                // remove user comments
                commentManager.removeUserComments(userid);

                // remove user
                UserManager userManager = new UserManager();
                if (userManager.removeUser(userid))
                {

                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("userManagementPanel -> RemoveUserClick() -> " + ex.Message_);
            }
        }

        protected void NewUserButtonClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("register.aspx");
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("userManagementPanel -> NewUserButtonClick() -> " + ex.Message_);
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
                exceptionManager.saveException("userManagementPanel -> LogoutButtonClick() -> " + ex.Message_);
            }
        }
    }
}