using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEST.Entities.Category;
using TEST.Services.Article;
using TEST.Services.Category;
using TEST.Web.Views.Article;

namespace TEST.Web.Views.Category
{
    public partial class CategoryCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    btnSave.Text = "Update";
                    hdnCategoryId.Value = Request.QueryString["id"].ToString();
                    BindData();
                }
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            AddOrUpdate();
        }

        protected void CancelBtn_Click(object sender, EventArgs e) 
        {
            Response.Redirect("~/Views/Category/CategoryList.aspx");
        }

        private void BindData()
        {
            CategoryService categoryService = new CategoryService();
            DataTable dt = categoryService.Get(Convert.ToInt32(hdnCategoryId.Value));
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtSlug.Text = dt.Rows[0]["Slug"].ToString();
                txtCreatedAt.Text = Convert.ToDateTime(dt.Rows[0]["CreatedAt"]).ToString("dd/MM/yyyy");
            }
        }

        private void AddOrUpdate()
        {
            CategoryService categoryService = new CategoryService();
            CategoryEntity categoryEntity = CreateData();
            bool success = false;

            if (hdnCategoryId.Value == "0")
            {
                success = categoryService.Insert(categoryEntity);
            }else
            {
                success = categoryService.Update(categoryEntity);
            }
            if (success)
            {
                Response.Redirect("~/Views/Category/CategoryList.aspx");
            }
        }

        private CategoryEntity CreateData()
        {
            CategoryEntity categoryEntity = new CategoryEntity();
            categoryEntity.CategoryId = Convert.ToInt32(hdnCategoryId.Value);
            categoryEntity.Name = txtName.Text.ToString();
            categoryEntity.Slug = GetSlug(txtSlug.Text.ToString());
            string[] date = txtCreatedAt.Text.Split('/');
            categoryEntity.CreatedAt = Convert.ToDateTime(date[2] + "-" + date[1] + "-" + date[0]);
            return categoryEntity;
        }
        private string GetSlug(string text)
        {
            string slug = text.ToLower();
            slug = Regex.Replace(slug, @"[^A-Za-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = Regex.Replace(slug, @"\s", "-");
            return slug;
        }
    }
}