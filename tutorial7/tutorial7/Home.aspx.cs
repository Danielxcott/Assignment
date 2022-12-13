using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tutorial7
{
    public partial class Home : Page
    {
        public string UserName { get { return (string)Session["email"]; } }
        public string Password { get { return (string)Session["password"]; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session.Count != 0)
                {
                    email.Text = UserName;
                    password.Text = Password;
                    name.InnerText = "Hello, " + UserName.Substring(0, UserName.IndexOf("@"));
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