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
            string fileextension = Path.GetExtension(fileUploadBox.PostedFile.FileName).ToLower();
            string filename = Path.GetFileName(fileUploadBox.FileName);
            string path = Server.MapPath("~/Files/") + filename;
            fileUploadBox.PostedFile.SaveAs(path);
            string filepath = Path.GetFullPath(path);

            if(File.Exists(filepath))
            {
                File.Delete(filepath);
                string newpath = Server.MapPath("~/Files/") + filename;
                fileUploadBox.PostedFile.SaveAs(newpath);
                string newfilepath = Path.GetFullPath(newpath);

                switch (fileextension)
                {
                    case ".txt":
                        GetTxtTable(newfilepath);
                        break;
                    case ".xlsx":
                        GetXlsxTable(newfilepath, "yes");
                        break;
                    case ".csv":
                        GetCsvTable(newfilepath);
                        break;
                    default:
                        lblErrorMsg.Style.Add("display", "block");
                        lblErrorMsg.Text = "The file extension doesn't support.";
                        lblErrorMsg.ForeColor = System.Drawing.Color.Red;
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
            gvList.DataSource = table;
            gvList.DataBind();
        }

        //View excel file table
        void GetXlsxTable(string path, string hdr)
        {
            FileInfo existingfile = new FileInfo(path);
            using (ExcelPackage package = new ExcelPackage(existingfile))
            {
                // get the first worksheet in the workbook
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowno = worksheet.Dimension.End.Row;

                DataTable dttemp = new DataTable();

                dttemp.Columns.Add("No");
                dttemp.Columns.Add("Name");
                dttemp.Columns.Add("Country");
                DataRow dradditem;

                for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                {
                    object col1Value = worksheet.Cells[row, 1].Value;
                    object col2Value = worksheet.Cells[row, 2].Value;
                    object col3Value = worksheet.Cells[row, 3].Value;

                    dradditem = dttemp.NewRow();

                    dradditem["No"] = col1Value.ToString();
                    dradditem["Name"] = col2Value.ToString();
                    dradditem["Country"] = col3Value.ToString();
                    dttemp.Rows.Add(dradditem);
                }
                gvList.DataSource = dttemp;
                gvList.DataBind();
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
            gvList.DataSource = table;
            gvList.DataBind();
        }
    }
}