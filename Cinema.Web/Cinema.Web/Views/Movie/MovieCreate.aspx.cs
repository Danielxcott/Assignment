using Cinema.Entities.Movie;
using Cinema.Entities.Salutation;
using Cinema.Services.Movie;
using Cinema.Services.Salutation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web.Views.Movie
{
    public partial class MovieCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    btnSave.Text = "Update";
                    hdnMovieId.Value = Request.QueryString["id"].ToString();
                    BindData();
                }
            }
        }

        private void BindData()
        {
            MovieService movieService = new MovieService();
            DataTable dt = movieService.Get(Convert.ToInt32(hdnMovieId.Value));
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["MoviesRented"].ToString();
            }
        }

        protected void SaveBtn(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        protected void CancelBtn(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Movie/MovieList.aspx");
        }

        private void AddOrUpdate()
        {
            MovieService movieService = new MovieService();
            MovieEntity movieEntity = CreateData();
            bool success = false;
            if (hdnMovieId.Value == "0")
            {

                int exist = movieService.Exist(movieEntity);
                if (exist > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Movie name had already existed in the lists, please write differ movie name.');", true);
                    btnSave.Enabled = false;
                }
                else
                {
                    success = movieService.Insert(movieEntity);
                    btnSave.Enabled = true;
                }
                btnSave.Enabled = true;
            }
            else
            {
                success = movieService.Update(movieEntity);
            }

            if (success)
            {
                Response.Redirect("~/Views/Movie/MovieList.aspx");
            }
        }

        private MovieEntity CreateData()
        {
            MovieEntity movieEntity = new MovieEntity();
            movieEntity.MovieId = Convert.ToInt32(hdnMovieId.Value);
            movieEntity.MoviesRented = txtName.Text.ToString();
            return movieEntity;
        }
    }
}