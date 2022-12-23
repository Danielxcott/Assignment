using Cinema.DAO.Common;
using Cinema.Entities.Member;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAO.Member
{
    public class MemberDao
    {
        DbConnection connection = new DbConnection();
        private string strSql = string.Empty;

        public DataTable GetAll()
        {
            strSql = "SELECT m.MemberId, m.FullName, m.Address, mo.MoviesRented, s.Salutation";
            strSql += " FROM Members m INNER JOIN Movies mo ON m.MovieId = mo.MovieId";
            strSql += " INNER JOIN Salutations s ON m.SalutationId = s.SalutationId";

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Members WHERE MemberId = " + id;
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable Search(string keyword)
        {
            strSql = "SELECT m.MemberId, m.FullName, m.Address, mo.MoviesRented, s.Salutation";
            strSql += " FROM Members m INNER JOIN Movies mo ON m.MovieId = mo.MovieId";
            strSql += " INNER JOIN Salutations s ON m.SalutationId = s.SalutationId WHERE m.FullName LIKE '%" + keyword + "%' OR mo.MoviesRented LIKE '%" + keyword + "%'";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public bool Insert(MemberEntity memberEntity)
        {
            strSql = "INSERT INTO Members (FullName,Address,MovieId,SalutationId) " + "VALUES (@FullName,@Address,@MovieId,@SalutationId)";
            SqlParameter[] sqlParams =
            {
                new SqlParameter("@FullName",memberEntity.FullName),
                new SqlParameter("@Address",memberEntity.Address),
                new SqlParameter("@MovieId",memberEntity.MovieId),
                new SqlParameter("@SalutationId",memberEntity.SalutationId)
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }

        public bool Update(MemberEntity memberEntity)
        {
            strSql = "UPDATE Members SET FullName = @FullName, Address = @Address, MovieId = @MovieId, SalutationId = @SalutationId WHERE MemberId = @MemberId";
            SqlParameter[] sqlParams =
            {
                new SqlParameter("@FullName",memberEntity.FullName),
                new SqlParameter("@Address",memberEntity.Address),
                new SqlParameter("@MovieId",memberEntity.MovieId),
                new SqlParameter("@SalutationId",memberEntity.SalutationId),
                new SqlParameter("@MemberId",memberEntity.MemberId),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }

        public bool Delete(int id)
        {
            strSql = "DELETE FROM Members WHERE MemberId = @MemberId";
            SqlParameter[] sqlParams =
            {
                new SqlParameter("@MemberId",id),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }
    }
}
