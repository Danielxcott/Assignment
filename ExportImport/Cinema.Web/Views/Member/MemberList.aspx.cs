using Cinema.Entities.Member;
using Cinema.Services.Member;
using Microsoft.Ajax.Utilities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Services.Description;
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

        protected void LnkExportBtn(object sender, EventArgs e)
        {
            MemberService memberService = new MemberService();
            DataTable dt = memberService.GetExport();
            var filepath = @"C:\Users\TheinZan\Desktop\Cinema.Web\Cinema.Web\Files\member.xlsx";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Worksheets.Add("Member").Cells[1,1].LoadFromDataTable(dt,true);
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                    excelPackage.SaveAs(new FileInfo(filepath));

                }
                excelPackage.SaveAs(new FileInfo(filepath));
            }
        }

        protected void LnkImportBtn(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(fuldImport.FileName);
            string path = Server.MapPath("~/Files/") + filename;
            string filepath = Path.GetFullPath(path);
            ImportExcel(filepath);
        }

        private void ImportExcel(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);

            using(ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                int rowno = excelWorksheet.Dimension.End.Row;
                MemberEntity memberEntity = new MemberEntity();
                MemberService memberService = new MemberService();
                for (int i = 2; i <= rowno; i++)
                {
                        memberEntity.MemberId = Convert.ToInt32(excelWorksheet.Cells[i, 1].Value);
                        memberEntity.FullName = Convert.ToString(excelWorksheet.Cells[i, 2].Value);
                        memberEntity.Address = Convert.ToString(excelWorksheet.Cells[i, 3].Value);
                        memberEntity.MovieId = Convert.ToInt32(excelWorksheet.Cells[i, 4].Value);
                        memberEntity.SalutationId = Convert.ToInt32(excelWorksheet.Cells[i, 5].Value);
                        memberService.Insert(memberEntity);
                }
                BindGrid();
            }
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