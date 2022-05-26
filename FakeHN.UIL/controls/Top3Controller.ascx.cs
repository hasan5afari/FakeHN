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
    public partial class Top3Controller : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTop3();
            }
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("Top3Controller -> Page_Load() -> " + ex.Message_);
            }
        }

        protected void LoadTop3()
        {
            try
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
            catch (BllException ex)
            {
                ExceptionManager exceptionManager = new ExceptionManager();
                exceptionManager.saveException("Top3Controller -> LoadTop3() -> " + ex.Message_);
            }
        }
    }
}