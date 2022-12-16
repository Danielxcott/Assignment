using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimeKit;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace tutorial10
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Reset_Btn(object sender, EventArgs e)
        {
           string mail = EmailBox0.Text.ToString();
            string body = string.Empty;
            using (StreamReader read = new StreamReader(Server.MapPath("~/Template/ResetMail.html")))
            {
                body = read.ReadToEnd();
            }
            SendMail(mail, body);
        }

        private void SendMail(string mail, string messageBody)
        {
            var versionName = new ComputerInfo().OSFullName;
            string username = mail.Substring(0, mail.IndexOf("@"));
            MailAddress from = new MailAddress(mail);
            MailAddress to = new MailAddress("Moon@mailtrap.io");
            MailMessage message = new MailMessage(from, to);
            message.Body = messageBody;
            message.IsBodyHtml = true;
            string mailbody = messageBody.Replace("#name#",username).Replace("#opertaion_system#", versionName).Replace("#browser_name#", HttpContext.Current.Request.Browser.Browser);
            message.Body = mailbody;
            message.Subject = "Hello ," + username;
            Session["status"] = "change on";

            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("b175e99d9a1a8e", "f40868ff58681c"),
                EnableSsl = true
            };
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}