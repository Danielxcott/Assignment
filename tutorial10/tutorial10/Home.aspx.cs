using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tutorial10
{
    public partial class Home : Page
    {
        public string UserName { get { return (string)Session["Email"]; } }
        public string Password { get { return (string)Session["Password"]; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session.Count != 0)
                {
                    lblEmail.Text = UserName;
                    lblPassword.Text = Password;
                    hdrName.InnerText = "Hello, " + UserName.Substring(0, UserName.IndexOf("@"));
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void Logout_Btn(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

    }
}