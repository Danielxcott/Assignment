using Cinema.Services.Movie;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web.Views.Movie
{
    public partial class MovieList : System.Web.UI.Page
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
            Response.Redirect("~/Views/Movie/MovieCreate.aspx");
        }

        private void BindGrid()
        {
            MovieService movieService = new MovieService();
            DataTable dt = movieService.GetAll();
            gvMovie.DataSource = dt;
            gvMovie.DataBind();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMovie.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void gvMovieRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/Views/Movie/MovieCreate.aspx?id=" + e.CommandArgument);
            }
        }

        protected void gvMovieRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label getId = (Label)gvMovie.Rows[e.RowIndex].FindControl("lblMovieID");
            MovieService movieService = new MovieService();
            bool success = movieService.Delete(Convert.ToInt32(getId.Text));
            if (success)
            {
                BindGrid();
            }
        }
    }
}