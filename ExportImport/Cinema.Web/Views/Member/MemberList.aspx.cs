using Cinema.Entities.Member;
using Cinema.Services.Member;
using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System;
using System.Web.UI;
using Cinema.Services.Movie;
using Cinema.Services.Salutation;

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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Excel file is successfully exported.');", true);
            MemberService memberService = new MemberService();
            DataTable dt = memberService.GetExport();
            var filepath = Server.MapPath("~/Files/") + "member.xlsx";
            ExportExcel(filepath, dt); 
            Response.ContentType = "Application/x-msexcel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=member.xlsx");
            Response.TransmitFile(filepath);
            Response.Flush();
            Response.End();
        }

        private void ExportExcel(string filepath,DataTable dt)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Worksheets.Add("Member").Cells[1, 1].LoadFromDataTable(dt, true);
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

            using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                int rowno = excelWorksheet.Dimension.End.Row;
                MemberEntity memberEntity = new MemberEntity();
                MemberService memberService = new MemberService();
                MovieService movieService = new MovieService();
                SalutationService salutationService = new SalutationService();

                for (int i = 2; i <= rowno; i++)
                {
                    memberEntity.FullName = Convert.ToString(excelWorksheet.Cells[i, 1].Value);
                    memberEntity.Address = Convert.ToString(excelWorksheet.Cells[i, 2].Value);
                    memberEntity.MovieId = movieService.CheckName(Convert.ToString(excelWorksheet.Cells[i, 3].Value));
                    memberEntity.SalutationId = salutationService.CheckName(Convert.ToString(excelWorksheet.Cells[i, 4].Value));
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
