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
            Session.Remove("Password");
            string newpassword = txtNPassword.Text.ToString();
            string confirmpassword = txtCPassword.Text.ToString();
            if(newpassword == confirmpassword)
            {
                Session["NcPassword"] = confirmpassword;
                Response.Redirect("Default.aspx");
            }else
            {
                ErrorMsg.InnerText = "Your new password and confirm password is not the same. Please, try again!";
                ErrorMsg.Style.Add("display", "inline-block");
                ErrorMsg.Style.Add("color", "Red");
                txtNPassword.Text = String.Empty;
                txtCPassword.Text = String.Empty;
            }
        }
    }
}