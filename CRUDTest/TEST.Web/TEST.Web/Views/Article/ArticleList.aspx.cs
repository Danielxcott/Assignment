using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEST.Services.Article;

namespace TEST.Web.Views.Article
{
    public partial class ArticleList : System.Web.UI.Page
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
            Response.Redirect("~/Views/Article/ArticleCreate.aspx");
        }

        private void BindGrid()
        {
            ArticleService articleService = new ArticleService();
            DataTable dt = articleService.GetAll();
            gvArticles.DataSource = dt;
            gvArticles.DataBind();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvArticles.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void gvArticle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/Views/Article/ArticleCreate.aspx?id=" + e.CommandArgument);
            }
        }

        protected void gvArticle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label getId = (Label)gvArticles.Rows[e.RowIndex].FindControl("lblArticleID");
            ArticleService articleService = new ArticleService();
            bool success = articleService.Delete(Convert.ToInt32(getId.Text));
            if(success)
            {
                BindGrid();
            }
        }
    }
}