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
            if (string.IsNullOrEmpty(Session["NcPassword"] as string))
            {
                Session["Email"] = "example@gmail.com";
                Session["Password"] = "1234";
            }
            else
            {
                Session["Email"] = "example@gmail.com";
                Session["Password"] = Session["NcPassword"];
            }
            var getemail = txtEmail.Text.ToString();
            var getpwd = txtPassword.Text.ToString();

            if (Convert.ToString(Session["Email"]) == getemail && Convert.ToString(Session["Password"]) == getpwd)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblErrorFeedback.Text = "Your email or password is incorrect";
                lblErrorFeedback.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Forget_Btn(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}