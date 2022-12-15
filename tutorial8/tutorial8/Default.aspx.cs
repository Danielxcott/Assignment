using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tutorial8
{
    public partial class _Default : Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=THEINZAN-PC;Initial Catalog=Dogs;User ID=sa;Password=Password2254@;Pooling=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewTable();
            }
        }
        protected void Create_Btn(object sender, EventArgs e)
        {
            if(NameCreate.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Required input field.');", true);
                GridView1.EditIndex = -1;
                ViewTable();
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
                    GridView1.EditIndex = -1;
                    ViewTable();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Name had already existed in the lists, please write differ name.');", true);
                    con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into [Dogs] (name) values(@name)", con);
                        cmd.Parameters.AddWithValue("@name", NameCreate.Text.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        NameCreate.Text = String.Empty;
                        UpdateBtn.Style.Add("display", "none");
                        CreateBtn.Style.Add("display", "inline-block"); 
                        GridView1.EditIndex = -1;
                        ViewTable();
                    }
                
            }
        }

        protected void Clear_Btn(object sender, EventArgs e)
        {
            NameCreate.Text = string.Empty;
            GridView1.EditIndex = -1;
            ViewTable();
        }

        protected void ViewTable()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=THEINZAN-PC;Initial Catalog=Dogs;User ID=sa;Password=Password2254@;Pooling=False"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * From [Dogs]"))
                {
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int getId = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Select id,name From [Dogs] Where id = @id", con);
            cmd.Parameters.AddWithValue("id", getId);
            CancelBtn.Style.Add("display", "inline-block");
            
             SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                Session["dogId"] = read.GetValue(0).ToString();
                NameCreate.Text = read.GetString(1).ToString();
                CreateBtn.Style["display"] = "none";
                UpdateBtn.Style["display"] = "inline-block";
                con.Close();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Something wrong!');", true);
                con.Close();
            }
            GridView1.EditIndex = -1;
            ViewTable();
        }

        protected void Cancel_Btn(object sender, EventArgs e)
        {
            UpdateBtn.Style.Add("display", "none");
            CancelBtn.Style.Add("display", "none");
            CreateBtn.Style.Add("display", "inline-block");
            NameCreate.Text = String.Empty;
            GridView1.EditIndex = -1;
            ViewTable();
        }

        protected void Update_Btn(object sender, EventArgs e)
        {
            if (NameCreate.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Required input field.');", true);
                GridView1.EditIndex = -1;
                ViewTable();
            }
            else
            {
                con.Open();
                
                    SqlCommand cmd = new SqlCommand("Update [Dogs] Set name = @name where id = @id ", con);
                    cmd.Parameters.AddWithValue("name", NameCreate.Text.ToString());
                    cmd.Parameters.AddWithValue("id", Session["dogId"]);
                    cmd.ExecuteNonQuery();

                    Session.Remove("dogId");
                    NameCreate.Text = String.Empty;
                    UpdateBtn.Style.Add("display", "none");
                     CancelBtn.Style.Add("display", "none");
                     CreateBtn.Style.Add("display", "inline-block");

                    GridView1.EditIndex = -1;
                    ViewTable();
                    con.Close();
                
            }

        }
    }
}