using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using TEST.Entities.Article;
using TEST.Services.Article;
using TEST.Services.Category;

namespace TEST.Web.Views.Article
{
    public partial class ArticleCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    btnSave.Text = "Update";
                    hdnPostId.Value = Request.QueryString["id"].ToString();
                    BindData();
                }
                BindGrid();
            }
        }

        protected void SaveBtnClick(object sender, EventArgs e)
        {
                AddOrUpdate();
        }

        protected void CancelBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Article/ArticleList.aspx");
        }

        private void BindData()
        {
            ArticleService articleService = new ArticleService();
            DataTable dt = articleService.Get(Convert.ToInt32(hdnPostId.Value));
            if (dt.Rows.Count > 0)
            {
                txtArticleTtl.Text = dt.Rows[0]["Title"].ToString();
                txtArticleSlug.Text = dt.Rows[0]["Slug"].ToString();
                txtArticleDescribe.Text = dt.Rows[0]["Description"].ToString();
                ddlCategory.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
            }
        }

        private void BindGrid()
        {
            CategoryService categoryService = new CategoryService();
            DataTable dt = categoryService.GetAll();
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select category", "0"));
            if (ddlCategory.SelectedIndex == 0)
            {
                ddlCategory.Items[0].Attributes["disabled"] = "disabled";
            }
        }

        private void AddOrUpdate()
        {
            ArticleService articleService = new ArticleService();
            ArticleEntity articleEntity = CreateData();
            bool success = false;
            if (hdnPostId.Value == "0")
            {
                 success = articleService.Insert(articleEntity);
            }else
            {
                 success = articleService.Update(articleEntity);
            }
            if(success)
            {
                Response.Redirect("~/Views/Article/ArticleList.aspx");
            }
        }

        private ArticleEntity CreateData()
        {
            ArticleEntity articleEntity = new ArticleEntity();
            articleEntity.ArticleId = Convert.ToInt32(hdnPostId.Value);
            articleEntity.CategoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            articleEntity.Title = txtArticleTtl.Text.ToString();
            articleEntity.Slug = GetSlug(txtArticleSlug.Text.ToString());
            articleEntity.Description = txtArticleDescribe.Text.ToString();
            articleEntity.Excerpt = GetExcerpt(txtArticleDescribe.Text.ToString());
            articleEntity.CreatedAt = DateTime.ParseExact(this.GetDate(),"dd-MM-yyyy",null);
            return articleEntity;
        }

        private string GetDate()
        {
           var now = DateTime.Now;
            var currentdate = now.ToString("dd-MM-yyyy");
            return currentdate;
        }

        private string GetSlug(string text)
        {
            string slug = text.ToLower();
            slug = Regex.Replace(slug, @"[^A-Za-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", " ").Trim();
            slug = Regex.Replace(slug, @"\s", "-");
            return slug;
        }

        private string GetExcerpt(string text)
        {
            int maxlength = 150;
            if(text.Length < maxlength)
            {
                return text;
            }else
            {
                var characterLength = 0;
                var words = text.Split(' ');
                var box = new List<string>();
                foreach ( var word in words )
                {
                    box.Add(word);
                    characterLength += word.Length + 1;
                    if(characterLength > maxlength)
                    {
                        break;
                    }
                }
                return string.Join(" ", box) + "...";
            }
            
        }
    }
}