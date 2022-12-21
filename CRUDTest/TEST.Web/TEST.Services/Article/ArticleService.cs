using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.DAO.Article;
using TEST.Entities.Article;

namespace TEST.Services.Article
{
    public class ArticleService
    {
        /// <summary>
        /// Define Article Dao..
        /// </summary>
        private ArticleDao articleDao = new ArticleDao();
        public DataTable GetAll()
        {
            DataTable dt = articleDao.GetAll();
            return dt;
        }


        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="id">.</param>
        /// <returns>.</returns>
        public DataTable Get(int id)
        {
            DataTable dt = articleDao.Get(id);
            return dt;
        }

        /// <summary>
        /// Save Article.
        /// </summary>
        /// <param name="ArticleEntity">.</param>
        public bool Insert (ArticleEntity articleEntity)
        {
            return articleDao.Insert(articleEntity);
        }

        /// <summary>
        /// Update Article.
        /// </summary>
        /// <param name="articleEntity">.</param>
        public bool Update(ArticleEntity articleEntity)
        {
            return articleDao.Update(articleEntity);
        }

        /// <summary>
        /// Delete Article.
        /// </summary>
        /// <param name="articleEntity">.</param>
        public bool Delete (int id)
        {
            return articleDao.Delete(id);
        }
    }
}
