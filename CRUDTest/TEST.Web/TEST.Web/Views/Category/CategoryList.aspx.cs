using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEST.Services.Category;

namespace TEST.Web.Views.Category
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void LnkBtn_Create(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Category/CategoryCreate.aspx");
        }

        private void BindGrid()
        {
            CategoryService categoryService = new CategoryService();
            DataTable dt = categoryService.GetAll();
            GVCategory.DataSource = dt;
            GVCategory.DataBind();
        }

        protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/Views/Category/CategoryCreate.aspx?id=" + e.CommandArgument);
            }
        }

        protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label getId = (Label)GVCategory.Rows[e.RowIndex].FindControl("lblCategoryID");
            CategoryService categoryService = new CategoryService();
            bool success = categoryService.Delete(Convert.ToInt32(getId.Text));
            if (success)
            {
                BindGrid();
            }
        }
    }
}