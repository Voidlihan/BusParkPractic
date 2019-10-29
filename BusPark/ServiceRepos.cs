using System;
using System.Collections.Generic;
using System.Text;
using BusPark.Entity;
using Dapper;
using System.Data.SqlClient;

namespace BusPark
{
    public class ServiceRepos
    {
        private readonly string connectionString = "Server=A-305-03;Database=BusPark;Trusted_Connection=True;";
        public ServiceRepos(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(Service service)
        {
            var sql = "Insert into Service (@Id, @Name, @BusId, @IsActual);";
            using (var connection = new SqlConnection())
            {
                var transaction = connection.BeginTransaction();
                var rowAffected = connection.Execute(sql, service, transaction);
                if (rowAffected != 1)
                {
                    throw new Exception("eror");
                }
            }
        }
        public Service GetServiceById(Guid id)
        {
            var sql = "Select top(1) from Service where Id=@Id;";
            using (var connection = new SqlConnection())
            {         
                return connection.QuerySingleOrDefault<Service>(sql, new { Id = id });
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
        public ICollection<Service> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = connection.CreateCommand())
            {
                string query = "select * from Service;";
                sqlCommand.CommandText = query;
                connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Service> service = new List<Service>();
                return service;
            }
        }
    }
}
