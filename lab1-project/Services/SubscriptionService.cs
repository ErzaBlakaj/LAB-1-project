using Dapper;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using lab1_project.Models;

namespace lab1_project.Services
{
    public class SubscriptionService
    {
        private string _connectionString { get; set; }

        public SubscriptionService(string connectionString)
        {
            _connectionString = connectionString;

        }
        public void InsertSubscription(string duration, int price)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new Dapper.DynamicParameters();
                        parameters.Add("@duration", duration);
                        parameters.Add("@price", price);

                        connection.Execute("InsertSubscription", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        //public List<Models.GetSubscription> GetSubscription()
        //{
        //    using (var connection = new SqlConnection())
        //    {
        //        connection.Open();

        //        var result = connection.Query<Models.GetSubscription>("GetSubscription", commandType: CommandType.StoredProcedure);

        //        return result.ToList();
        //    }
        //}
        public void DeleteSubscription(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", id);

                        connection.Execute("DeleteSubscription", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void UpdateSubscription(string duration, int price)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new Dapper.DynamicParameters();
                        parameters.Add("@duration", duration);
                        parameters.Add("@price", price);



                        connection.Execute("UpdateSubscription", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
    
}

