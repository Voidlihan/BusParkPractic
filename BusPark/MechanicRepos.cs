using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BusPark.Entity;
using Dapper;

namespace BusPark
{
    public class MechanicRepos
    {
        private readonly string connectionString = "Server=A-305-03;Database=BusPark;Trusted_Connection=True;";
        public MechanicRepos(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(Mechanic mech)
        {
            var sql = "Insert into Mechanic (@Id, @Name, @ServiceId, @BusId, @IsWorking);";
            using (var connection = new SqlConnection())
            {
                var transaction = connection.BeginTransaction();
                var rowAffected = connection.Execute(sql, mech, transaction);
                if (rowAffected != 1)
                {
                    throw new Exception("eror");
                }
            }
        }
        public Mechanic GetMechById(Guid id)
        {
            var sql = "Select top(1) from Mechanic where Id=@Id;";
            using (var connection = new SqlConnection())
            {               
                return connection.QuerySingleOrDefault<Mechanic>(sql, new { Id = id });
            }
        }
        private void ExecuteCommandsInTransaction(params SqlCommand[] commands)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var command in commands)
                    {
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        public ICollection<Mechanic> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = connection.CreateCommand())
            {
                string query = "select * from Mechanic;";
                sqlCommand.CommandText = query;
                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Mechanic> mech = new List<Mechanic>();
                return mech;
            }
        }
    }
}
