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
            if(txtName.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Required input field.');", true);
                gvDogLists.EditIndex = -1;
                ViewTable();
            }
            else
            {
             if(txtName.Text.ToString().Length < 3)
                {
                    lblMax.Text = "Name must be at least in 3 lengths.";
                    txtName.Text = String.Empty;
                }else
                {
                    con.Open();
                    SqlCommand check = new SqlCommand("Select name From [Dogs] Where name = @name", con);
                    check.Parameters.AddWithValue("@name", txtName.Text.ToString());
                    SqlDataAdapter sa = new SqlDataAdapter(check);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvDogLists.EditIndex = -1;
                        ViewTable();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Name had already existed in the lists, please write differ name.');", true);
                        con.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Insert into [Dogs] (name) values(@name)", con);
                        cmd.Parameters.AddWithValue("@name", txtName.Text.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        txtName.Text = String.Empty;
                        btnUpdate.Style.Add("display", "none");
                        btnCreate.Style.Add("display", "inline-block");
                        gvDogLists.EditIndex = -1;
                        ViewTable();
                    }
                }      
                
            }
        }

        protected void Clear_Btn(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            gvDogLists.EditIndex = -1;
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
                            gvDogLists.DataSource = dt;
                            gvDogLists.DataBind();
                        }
                    }
                }
            }
        }
        protected void gvDogs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvDogLists.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [Dogs] where id='" + Convert.ToInt32(gvDogLists.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ViewTable();
        }

        protected void gvDogs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int getId = Convert.ToInt32(gvDogLists.DataKeys[e.NewEditIndex].Value.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Select id,name From [Dogs] Where id = @id", con);
            cmd.Parameters.AddWithValue("id", getId);
            btnCancel.Style.Add("display", "inline-block");
            
             SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                Session["DogId"] = read.GetValue(0).ToString();
                txtName.Text = read.GetString(1).ToString();
                btnCreate.Style["display"] = "none";
                btnUpdate.Style["display"] = "inline-block";
                con.Close();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Something wrong!');", true);
                con.Close();
            }
            gvDogLists.EditIndex = -1;
            ViewTable();
        }

        protected void Cancel_Btn(object sender, EventArgs e)
        {
            btnUpdate.Style.Add("display", "none");
            btnCancel.Style.Add("display", "none");
            btnCreate.Style.Add("display", "inline-block");
            txtName.Text = String.Empty;
            gvDogLists.EditIndex = -1;
            ViewTable();
        }

        protected void Update_Btn(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Required input field.');", true);
                gvDogLists.EditIndex = -1;
                ViewTable();
            }
            else
            {
                if (txtName.Text.ToString().Length < 3)
                {
                    lblMax.Text = "Name must be at least in 3 lengths.";
                    txtName.Text = String.Empty;
                    gvDogLists.EditIndex = -1;
                    ViewTable();
                }
                else
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Update [Dogs] Set name = @name where id = @id ", con);
                    cmd.Parameters.AddWithValue("name", txtName.Text.ToString());
                    cmd.Parameters.AddWithValue("id", Session["DogId"]);
                    cmd.ExecuteNonQuery();

                    Session.Remove("DogId");
                    txtName.Text = String.Empty;
                    btnUpdate.Style.Add("display", "none");
                    btnCancel.Style.Add("display", "none");
                    btnCreate.Style.Add("display", "inline-block");

                    gvDogLists.EditIndex = -1;
                    ViewTable();
                    con.Close();
                }
                
            }

        }
    }
}