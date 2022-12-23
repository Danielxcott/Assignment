using Cinema.Services.Member;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web.Views.Member
{
    public partial class MemberList : System.Web.UI.Page
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
            Response.Redirect("~/Views/Member/MemberCreate.aspx");
        }

        protected void SearchBtn(object sender, EventArgs e)
        {
            MemberService memberService = new MemberService();
            string keyword = txtSearch.Text.ToString();
            DataTable dt = memberService.Search(keyword);
            gvMember.DataSource = dt;
            gvMember.DataBind();
        }

        private void BindGrid()
        {
            MemberService memberService = new MemberService();
            DataTable dt = memberService.GetAll();
            gvMember.DataSource = dt;
            gvMember.DataBind();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMember.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void gvMemberRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("~/Views/Member/MemberCreate.aspx?id=" + e.CommandArgument);
            }
        }

        protected void gvMemberRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label getId = (Label)gvMember.Rows[e.RowIndex].FindControl("lblMemberID");
            MemberService memberService = new MemberService();
            bool success = memberService.Delete(Convert.ToInt32(getId.Text));
            if (success)
            {
                BindGrid();
            }
        }
    }
}