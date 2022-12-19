using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEST.Entities.Article;
using TEST.Services.Article;
using static System.Net.Mime.MediaTypeNames;

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
                    HiddenPostId.Value = Request.QueryString["id"].ToString();
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
            Response.Redirect("~/Views/Article/ArticleList.aspx");
        }

        private void BindData()
        {
            ArticleService articleService = new ArticleService();
            DataTable dt = articleService.Get(Convert.ToInt32(HiddenPostId.Value));
            if (dt.Rows.Count > 0)
            {
                articleTtl.Text = dt.Rows[0]["Title"].ToString();
                articleSlug.Text = dt.Rows[0]["Slug"].ToString();
                articleDescribe.Text = dt.Rows[0]["Description"].ToString();
                articleCreated.Text = Convert.ToDateTime(dt.Rows[0]["CreatedAt"]).ToString("dd/MM/yyyy");
            }
        }

        private void AddOrUpdate()
        {
            ArticleService articleService = new ArticleService();
            ArticleEntity articleEntity = CreateData();
            bool success = false;
            if (HiddenPostId.Value == "0")
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
            articleEntity.ArticleId = Convert.ToInt32(HiddenPostId.Value);
            articleEntity.Title = articleTtl.Text.ToString();
            articleEntity.Slug = GetSlug(articleSlug.Text.ToString());
            articleEntity.Description = articleDescribe.Text.ToString();
            articleEntity.Excerpt = GetExcerpt(articleDescribe.Text.ToString());
            string[] date = articleCreated.Text.Split('/');
            articleEntity.CreatedAt = Convert.ToDateTime(date[2] + "-" + date[1] + "-" + date[0]);
            return articleEntity;
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
            int maxLength = 150;
            if(text.Length < maxLength)
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
                    if(characterLength > maxLength)
                    {
                        break;
                    }
                }
                return string.Join(" ", box) + "...";
            }
            
        }
    }
}