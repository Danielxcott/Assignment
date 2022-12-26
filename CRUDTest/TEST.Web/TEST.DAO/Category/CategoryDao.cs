using System.Data;
using System.Data.SqlClient;
using TEST.DAO.Common;
using TEST.Entities.Category;

namespace TEST.DAO.Category
{
    public class CategoryDao
    {
        private DbConnection connection = new DbConnection();

        private string strSql = string.Empty;

        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Categories";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Categories " +
                      "WHERE  CategoryId = " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public bool Insert(CategoryEntity categoryEntity)
        {
            strSql = "INSERT INTO Categories(Name,Slug,CreatedAt)" + "VALUES (@Name,@Slug,@CreatedAt)";
            SqlParameter[] sqlParams = {
                new SqlParameter("@Name",categoryEntity.Name),
                new SqlParameter("@Slug",categoryEntity.Slug),
                new SqlParameter("@CreatedAt",categoryEntity.CreatedAt),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }

        public bool Update(CategoryEntity categoryEntity)
        {
            strSql = "UPDATE Categories SET Name=@Name,Slug=@Slug,CreatedAt=@CreatedAt WHERE CategoryId = @CategoryId";
            SqlParameter[] sqlParams = {
                new SqlParameter("@CategoryId",categoryEntity.CategoryId),
                new SqlParameter("@Name",categoryEntity.Name),
                new SqlParameter("@Slug",categoryEntity.Slug),
                new SqlParameter("@CreatedAt",categoryEntity.CreatedAt),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }

        public bool Delete(int id)
        {
            strSql = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@CategoryId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
    }
}
