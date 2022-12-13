using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tutorial8
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ViewTable();
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=THEINZAN-PC;Initial Catalog=Dogs;User ID=sa;Password=Password2254@;Pooling=False");

        protected void Create_Btn(object sender, EventArgs e)
        {
            if(NameCreate.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Required input field.');", true);
            }
            else
            {
                    con.Open();
                    SqlCommand check = new SqlCommand("Select name From [Dogs] Where name = @name",con);
                    check.Parameters.AddWithValue("@name", NameCreate.Text.ToString());
                    SqlDataAdapter sa = new SqlDataAdapter(check);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Name had already existed in the lists, write different name.');", true);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into [Dogs] (name) values(@name)", con);
                        cmd.Parameters.AddWithValue("@name", NameCreate.Text.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("Default.aspx");
                        ViewTable();
                    }
                
            }
        }

        protected void Clear_Btn(object sender, EventArgs e)
        {
            NameCreate.Text = string.Empty; 
        }

        protected void ViewTable()
        {
            SqlCommand cmd = new SqlCommand("Select * From [Dogs]",con);
            DataTable dt = new DataTable();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            sa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [Dogs] where id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ViewTable();
        }

        protected void GridView1_RowEditing(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Update_Btn(object sender, EventArgs e)
        {

        }
    }
}