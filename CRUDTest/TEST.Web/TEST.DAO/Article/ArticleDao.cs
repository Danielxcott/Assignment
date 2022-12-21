using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.DAO.Common;
using TEST.Entities.Article;

namespace TEST.DAO.Article
{
    public class ArticleDao
    {
        private DbConnection connection = new DbConnection();

        private string strSql = string.Empty;

        private DataTable resultDataTable = new DataTable();

        private int existCount;

        public DataTable GetAll()
        {
            strSql = "SELECT a.ArticleId, c.Name, a.Title, a.Slug, a.Description, a.Excerpt, a.CreatedAt";
            strSql += " FROM Articles a INNER JOIN Categories c on a.CategoryId = c.CategoryId";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Articles " +
                      "WHERE  ArticleId= " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }


        public bool Insert(ArticleEntity articleEntity) {
                strSql = "INSERT INTO Articles(Title,Slug,Description,Excerpt,CategoryId,CreatedAt)"+"VALUES (@Title,@Slug,@Description,@Excerpt,@CategoryId,@CreatedAt)";
            SqlParameter[] sqlParams = {
                new SqlParameter("@Title",articleEntity.Title),
                new SqlParameter("@Slug",articleEntity.Slug),
                new SqlParameter("@Description",articleEntity.Description),
                new SqlParameter("@Excerpt",articleEntity.Excerpt),
                new SqlParameter("@CategoryId",articleEntity.CategoryId),
                new SqlParameter("@CreatedAt",articleEntity.CreatedAt),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql ,sqlParams);
            return success;
            }
        
        public bool Update(ArticleEntity articleEntity)
        {
            strSql = "UPDATE Articles SET CategoryId=@CategoryId, Title=@Title,Slug=@Slug,Description=@Description,Excerpt=@Excerpt,CreatedAt=@CreatedAt WHERE ArticleId = @ArticleId";
            SqlParameter[] sqlParams = {
                new SqlParameter("@ArticleId",articleEntity.ArticleId),
                new SqlParameter("@CategoryId",articleEntity.CategoryId),
                new SqlParameter("@Title",articleEntity.Title),
                new SqlParameter("@Slug",articleEntity.Slug),
                new SqlParameter("@Description",articleEntity.Description),
                new SqlParameter("@Excerpt",articleEntity.Excerpt),
                new SqlParameter("@CreatedAt",articleEntity.CreatedAt),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text,strSql ,sqlParams);
            return success;
        }

        public bool Delete(int id)
        {
            strSql = "DELETE FROM Articles WHERE ArticleId = @ArticleId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@ArticleId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
    }
}
