using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tutorial10
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Change_Password(Object sender, EventArgs e)
        {
            Session.Remove("password");
            string newPassword = NPassword.Text.ToString();
            string confirmPassword = CPassword.Text.ToString();
            if(newPassword == confirmPassword)
            {
                Session["ncpassword"] = confirmPassword;
                Response.Redirect("Default.aspx");
            }else
            {
                ErrorMsg.InnerText = "Your new password and confirm password is not the same. Please, try again!";
                ErrorMsg.Style.Add("display", "inline-block");
                ErrorMsg.Style.Add("color", "Red");
                NPassword.Text = String.Empty;
                CPassword.Text = String.Empty;
            }
        }
    }
}