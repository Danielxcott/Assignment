using OfficeOpenXml;
using System;
using System.Data;
using System.IO;
using System.Web.UI;

namespace tutorial9
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Upload_Btn(object sender, EventArgs e)
        {
            string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
            string fileName = Path.GetFileName(FileUpload1.FileName);
            string path = Server.MapPath("~/Files/") + fileName;
            FileUpload1.PostedFile.SaveAs(path);
            string filePath = Path.GetFullPath(path);

            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                string newPath = Server.MapPath("~/Files/") + fileName;
                FileUpload1.PostedFile.SaveAs(newPath);
                string newFilePath = Path.GetFullPath(newPath);

                switch (fileExtension)
                {
                    case ".txt":
                        GetTxtTable(newFilePath);
                        break;
                    case ".xlsx":
                        GetXlsxTable(newFilePath, "yes");
                        break;
                    case ".csv":
                        GetCsvTable(newFilePath);
                        break;
                    default:
                        ErrorMsg.Style.Add("display", "block");
                        ErrorMsg.Text = "The file extension doesn't support.";
                        ErrorMsg.ForeColor = System.Drawing.Color.Red;
                        break;
                }
            }
            
        }

        //View txt file table
        void GetTxtTable(string path)
        {
            DataTable table = new DataTable();
            table.Columns.Add("No");
            table.Columns.Add("Product");
            table.Columns.Add("Category");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price");
            table.Columns.Add("Status");

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split(',');
                    table.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
                }
            }
            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        //View excel file table
        void GetXlsxTable(string path, string hdr)
        {
            FileInfo existingFile = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                // get the first worksheet in the workbook
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowno = worksheet.Dimension.End.Row;

                DataTable dtTemp = new DataTable();

                dtTemp.Columns.Add("No");
                dtTemp.Columns.Add("Name");
                dtTemp.Columns.Add("Country");
                DataRow drAddItem;

                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    object col1Value = worksheet.Cells[row, 1].Value;
                    object col2Value = worksheet.Cells[row, 2].Value;
                    object col3Value = worksheet.Cells[row, 3].Value;

                    drAddItem = dtTemp.NewRow();

                    drAddItem["No"] = col1Value.ToString();
                    drAddItem["Name"] = col2Value.ToString();
                    drAddItem["Country"] = col3Value.ToString();
                    dtTemp.Rows.Add(drAddItem);
                }
                GridView1.DataSource = dtTemp;
                GridView1.DataBind();
            }
        }
        //View Csv file table
        void GetCsvTable(string pathFile)
        {
            DataTable table = new DataTable();
            table.Columns.Add("No");
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            table.Columns.Add("Occupation");
            table.Columns.Add("Sport");

            using (StreamReader sr = new StreamReader(pathFile))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split('|');
                    table.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4]);
                }
            }
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}