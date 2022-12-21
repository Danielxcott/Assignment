using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tutorial7
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        protected void LoginBtn(object sender, EventArgs e)
        {
            Session["Email"] = "example@gmail.com";
            Session["Password"] = "1234";
            var email = txtEmail.Text.ToString();
            var password = txtPassword.Text.ToString();

            if (Convert.ToString(Session["Email"]) == email && Convert.ToString(Session["Password"]) == password)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblErrorFeedback.Text = "Your email or password is incorrect";
                lblErrorFeedback.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}