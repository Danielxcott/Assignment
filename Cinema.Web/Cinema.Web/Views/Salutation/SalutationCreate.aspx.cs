using Cinema.Entities.Salutation;
using Cinema.Services.Salutation;
using System;
using System.Data;
using System.Web.UI;

namespace Cinema.Web.Views.Salutation
{
    public partial class SalutationCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    btnSave.Text = "Update";
                    hdnSalutationId.Value = Request.QueryString["id"].ToString();
                    BindData();
                }
            }
        }

        protected void SaveBtn(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        protected void CancelBtn(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Salutation/SalutationList.aspx");
        }

        private void BindData()
        {
            SalutationService salutationService = new SalutationService();
            DataTable dt = salutationService.Get(Convert.ToInt32(hdnSalutationId.Value));
            if (dt.Rows.Count > 0)
            {
                txtSalutation.Text = dt.Rows[0]["Salutation"].ToString();
            }
        }

        private void AddOrUpdate()
        {
            SalutationService salutationService = new SalutationService();
            SalutationEntity salutationEntity = CreateData();
            int exist = salutationService.Exist(salutationEntity);
            bool success = false;
            if (hdnSalutationId.Value == "0")
            {
                if(exist > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Type of Salutation had already existed in the lists, please write differ salutation.');", true);
                    btnSave.Enabled = false;
               }
                else
                {
                    success = salutationService.Insert(salutationEntity);
                    btnSave.Enabled = true;
                }
                btnSave.Enabled = true;
            }
            else
            {
                if (exist > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Type of Salutation had already existed in the lists, please write differ salutation.');", true);
                    btnSave.Enabled = false;
                }
                else
                {
                    success = salutationService.Update(salutationEntity);
                    btnSave.Enabled = true;
                }
                btnSave.Enabled = true;
            }
            if (success)
            {
                Response.Redirect("~/Views/Salutation/SalutationList.aspx");
            }
        }

        private SalutationEntity CreateData()
        {
            SalutationEntity salutationEntity = new SalutationEntity();
                salutationEntity.SalutationId = Convert.ToInt32(hdnSalutationId.Value);
                salutationEntity.Salutation = txtSalutation.Text.ToString();
                return salutationEntity;
        }
    }
}