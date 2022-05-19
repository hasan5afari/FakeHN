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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButtonClick(object sender, EventArgs e)
        {
            if (!(registerFormName.Value == "" || registerFormFamily.Value == "" ||
                  registerFormUsername.Value == ""   || registerFormPassword.Value == ""))
            {
                UserManager userManager = new UserManager();
                string username = registerFormUsername.Value;
                string password = registerFormPassword.Value;
                string name = registerFormName.Value;
                string family = registerFormFamily.Value;

                if (!userManager.usernameExists(username))
                {
                    if (Utilities.isValidName(name) && Utilities.isValidName(family) && Utilities.isValidName(password) && Utilities.isValidName(username))
                    {
                        User user = new User();
                        user.username = username;
                        user.password = password;
                        user.name = name;
                        user.family = family;
                        if (userManager.registerUser(user))
                            registerResult.InnerText = "Successfully registerd. now you can log in to system";
                        else
                            registerResult.InnerText = "Registration failed . try again later .";
                    }
                    else
                    {
                        registerResult.InnerText = "Invalid Name, Family, Username or Password";
                    }
                }
                else
                {
                    registerResult.InnerText = "Username already exists .";
                }
            }
            else
            {
                registerResult.InnerText = "You have to fill all fields .";
            }
        }
    }
}