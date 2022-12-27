using Cinema.Services.Salutation;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Cinema.Web.Views.Salutation
{
    public partial class SalutationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void LnkBtnCreate(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Salutation/SalutationCreate.aspx");
        }

        private void BindGrid()
        {
            SalutationService salutationService = new SalutationService();
            DataTable dt = salutationService.GetAll();
            gvSalutation.DataSource = dt;
            gvSalutation.DataBind();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalutation.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void gvSalutationRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/Views/Salutation/SalutationCreate.aspx?id=" + e.CommandArgument);
            }
        }

        protected void gvSalutationRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label getId = (Label)gvSalutation.Rows[e.RowIndex].FindControl("lblSalutationID");
            SalutationService salutationService = new SalutationService();
            bool success = salutationService.Delete(Convert.ToInt32(getId.Text));
            if (success)
            {
                BindGrid();
            }
        }
    }
}