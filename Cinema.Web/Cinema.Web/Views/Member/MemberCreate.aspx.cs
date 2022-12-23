using Cinema.Entities.Member;
using Cinema.Services.Member;
using Cinema.Services.Movie;
using Cinema.Services.Salutation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web.Views.Member
{
    public partial class MemberCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    btnSave.Text = "Update";
                    hdnMemberId.Value = Request.QueryString["id"].ToString();
                    BindData();
                }
                BindMovieList();
                BindSalutationList();
            }
        }

        private void BindMovieList()
        {
            MovieService movieService = new MovieService();
            DataTable dt = movieService.GetAll();
            ddlMovie.DataSource = dt;
            ddlMovie.DataTextField = "MoviesRented";
            ddlMovie.DataValueField = "MovieId";
            ddlMovie.DataBind();
            ddlMovie.Items.Insert(0, new ListItem("Select movie from the lists ", "0"));
            if (ddlMovie.SelectedIndex == 0)
            {
                ddlMovie.Items[0].Attributes["disabled"] = "disabled";
            }
        }

        private void BindSalutationList()
        {
            SalutationService salutationService = new SalutationService();
            DataTable dt = salutationService.GetAll();
            ddlSalutation.DataSource = dt;
            ddlSalutation.DataTextField = "Salutation";
            ddlSalutation.DataValueField = "SalutationId";
            ddlSalutation.DataBind();
            ddlSalutation.Items.Insert(0, new ListItem("Select a salutation ", "0"));
            if (ddlSalutation.SelectedIndex == 0)
            {
                ddlSalutation.Items[0].Attributes["disabled"] = "disabled";
            }
        }

        private void BindData()
        {
            MemberService memberService = new MemberService();
            DataTable dt = memberService.Get(Convert.ToInt32(hdnMemberId.Value));
            if (dt.Rows.Count > 0)
            {
                txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                ddlMovie.SelectedValue = dt.Rows[0]["MovieId"].ToString();
                ddlSalutation.SelectedValue = dt.Rows[0]["SalutationId"].ToString();
            }
        }

        protected void SaveBtn(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        protected void CancelBtn(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/MemberList.aspx");
        }

        private void AddOrUpdate()
        {
            MemberService memberService = new MemberService();
            MemberEntity memberEntity = CreateData();
            bool success = false;
            if (hdnMemberId.Value == "0")
            {
                success = memberService.Insert(memberEntity);
            }
            else
            {
                success = memberService.Update(memberEntity);
            }

            if (success)
            {
                Response.Redirect("~/Views/Member/MemberList.aspx");
            }
        }

        private MemberEntity CreateData()
        {
            MemberEntity memberEntity = new MemberEntity();
            memberEntity.MemberId = Convert.ToInt32(hdnMemberId.Value);
            memberEntity.FullName = txtFullName.Text.ToString();
            memberEntity.Address = txtAddress.Text.ToString();
            memberEntity.SalutationId = Convert.ToInt32(ddlSalutation.SelectedItem.Value);
            memberEntity.MovieId = Convert.ToInt32(ddlMovie.SelectedItem.Value);
            return memberEntity;
        }
    }
}
