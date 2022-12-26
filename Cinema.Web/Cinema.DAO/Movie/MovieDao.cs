using Cinema.DAO.Common;
using Cinema.Entities.Movie;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAO.Movie
{
    public class MovieDao
    {
        DbConnection connection = new DbConnection();
        private string strSql = string.Empty;

        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Movies";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable Get(int id) {
            strSql = "SELECT * FROM Movies WHERE MovieId = " + id;
            return connection.ExecuteDataTable (CommandType.Text, strSql);
        }
        public int Exist(MovieEntity movieEntity)
        {
            strSql = "SELECT Count(MoviesRented) FROM Movies WHERE MoviesRented = " + "@MoviesRented";
            SqlParameter[] sqlParams = {
                new SqlParameter("@MoviesRented",movieEntity.MoviesRented),
            };
            return Convert.ToInt32(connection.ExecuteScalar(CommandType.Text, strSql, sqlParams));
        }


        public bool Insert(MovieEntity movieEntity)
        {
            strSql = "INSERT INTO Movies (MoviesRented) " + "VALUES (@MoviesRented)";
            SqlParameter[] sqlParams = {
                new SqlParameter("@MoviesRented",movieEntity.MoviesRented),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text,strSql,sqlParams);
            return success;
        }

        public bool Update(MovieEntity movieEntity)
        {
            strSql = "UPDATE Movies SET MoviesRented = @MoviesRented WHERE MovieId = @MovieId";
            SqlParameter[] sqlParams = {
            new SqlParameter("@MovieId",movieEntity.MovieId),
            new SqlParameter("@MoviesRented",movieEntity.MoviesRented)
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }

        public bool Delete(int id)
        {
            strSql = "DELETE FROM Movies WHERE MovieId = @MovieId";
            SqlParameter[] sqlParams =
            {
                new SqlParameter("@MovieId",id),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }
    }
}
