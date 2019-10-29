using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using BusPark.Entity;
using System.Data.SqlClient;

namespace BusPark
{
    public class BusRepos
    {
        private readonly string connectionString = "Server=A-305-03;Database=BusPark;Trusted_Connection=True;";
        public BusRepos(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(Bus bus)
        {
            var sql = "Insert into Bus (@Id, @Name, @MechanicId, @IsMechanicWorking, @ServiceId);";
            using (var connection = new SqlConnection(connectionString))
            {
                var transaction = connection.BeginTransaction();
                var rowAffected = connection.Execute(sql, bus, transaction);
                if (rowAffected != 1)
                {
                    throw new Exception("eror");
                }
            }
        }
        public Bus GetUserById(Guid id)
        {
            var sql = "Select top(1) from Bus where Id=@Id;";
            using (var connection = new SqlConnection(connectionString))
            {            
                return connection.QuerySingleOrDefault<Bus>(sql, new { Id = id });
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
        public ICollection<Bus> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = connection.CreateCommand())
            {
                string query = "select * from Bus;";
                sqlCommand.CommandText = query;
                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Bus> bus = new List<Bus>();
                return bus;
            }
        }
    }
}
