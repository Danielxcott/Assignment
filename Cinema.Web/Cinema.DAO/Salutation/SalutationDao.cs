﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DAO.Common;
using Cinema.Entities.Salutation;

namespace Cinema.DAO.Salutation
{
    public class SalutationDao
    {
        private DbConnection connection = new DbConnection();
        private string strSql = string.Empty;

        public DataTable GetAll()
        {
            strSql = "SELECT * FROM Salutations ";
            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public DataTable Get(int id)
        {
            strSql = "SELECT * FROM Salutations " +
                      "WHERE  SalutationId = " + id;

            return connection.ExecuteDataTable(CommandType.Text, strSql);
        }

        public bool Insert(SalutationEntity salutationEntity)
        {
            strSql = "INSERT INTO Salutations (Salutation)" + "VALUES (@Salutation)";
            SqlParameter[] sqlParams = {
                new SqlParameter("@Salutation",salutationEntity.Salutation),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }

        public bool Update(SalutationEntity salutationEntity)
        {
            strSql = "UPDATE Salutations SET Salutation=@Salutation WHERE SalutationId = @SalutationId";
            SqlParameter[] sqlParams = {
                new SqlParameter("@Salutation",salutationEntity.Salutation),
                 new SqlParameter("@SalutationId",salutationEntity.SalutationId),
            };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParams);
            return success;
        }

        public bool Delete(int id)
        {
            strSql = "DELETE FROM Salutations WHERE SalutationId = @SalutationId";
            SqlParameter[] sqlParam = {
                                        new SqlParameter("@SalutationId", id)
                                      };
            bool success = connection.ExecuteNonQuery(CommandType.Text, strSql, sqlParam);
            return success;
        }
    }
}
