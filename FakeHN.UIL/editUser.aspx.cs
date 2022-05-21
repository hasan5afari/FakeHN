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
        private User editing_user;
        private User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            // load editing user
            int userid = Convert.ToInt32(Request.Cookies["editing_user"].Value);
            UserManager userManager = new UserManager();
            editing_user = userManager.getUser(userid);

            if (!IsPostBack)
            {
                editFormUsername.Value = editing_user.username;
                editFormPassword.Value = editing_user.password;
                editFormName.Value = editing_user.name;
                editFormFamily.Value = editing_user.family;
            }
        }

        protected void SaveEditsButtonClick(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            editing_user.username = editFormUsername.Value;
            editing_user.password = editFormPassword.Value;
            editing_user.name = editFormName.Value;
            editing_user.family = editFormFamily.Value;

            if (userManager.updateUser(editing_user))
            {
                Response.Redirect("userManagementPanel.aspx");
            }
            else
            {
                editUserResult.InnerText = "Failed to edit the user !";
            }
        }
    }
}