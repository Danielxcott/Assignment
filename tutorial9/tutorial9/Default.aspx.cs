using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

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
            string filePaths = Path.GetFullPath(path);

            switch (fileExtension)
            {
                case ".txt":
                    GetTxtTable(filePaths);
                    break;
                case ".xlsx":
                    GetXlsxTable(filePaths, "yes");
                    break;
                case ".csv":
                    GetCsvTable(filePaths);
                    break;
                default:
                    ErrorMsg.Style.Add("display", "block");
                    ErrorMsg.Text = "The file extension doesn't support.";
                    ErrorMsg.ForeColor = System.Drawing.Color.Red;
                    break;
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
        void GetXlsxTable(string path,string hdr)
        {
            string con = ConfigurationManager.ConnectionStrings["excelcon"].ConnectionString;
            con = string.Format(con, path, hdr);
            OleDbConnection excelcon = new OleDbConnection(con);
            excelcon.Open();
            DataTable exceldt = excelcon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string excelSheetName = exceldt.Rows[0]["TABLE_NAME"].ToString();
            OleDbCommand cmd = new OleDbCommand("Select * From [" + excelSheetName + "]", excelcon);
            OleDbDataAdapter oda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            excelcon.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //View Csv file table
        void GetCsvTable(string path)
        {
            DataTable table = new DataTable();
            table.Columns.Add("No");
            table.Columns.Add("Name");
            table.Columns.Add("Age");
            table.Columns.Add("Occupation");
            table.Columns.Add("Sport");

            using (StreamReader sr = new StreamReader(path))
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

   