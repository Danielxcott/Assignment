using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tutorial10
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Btn(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["ncpassword"] as string))
            {
                Session["email"] = "example@gmail.com";
                Session["password"] = "1234";
            }
            else
            {
                Session["email"] = "example@gmail.com";
                Session["password"] = Session["ncpassword"];
            }
            var getEmail = email.Text.ToString();
            var getPwd = password.Text.ToString();

            if (Convert.ToString(Session["email"]) == getEmail && Convert.ToString(Session["password"]) == getPwd)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                ErrorFeedback.Text = "Your email or password is incorrect";
                ErrorFeedback.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Forget_Btn(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}