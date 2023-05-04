using Dapper;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using lab1_project.Models;

namespace lab1_project.Services
{
    public class InfromacionetService
    {
        private string _connectionString { get; set; }

        public InfromacionetService(string connectionString)
        {
            _connectionString = connectionString;

        }
        public void InsertInfromacionet(string title, string description)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new Dapper.DynamicParameters();
                        parameters.Add("@Titulli", title);
                        parameters.Add("@Pershkrimi", description);
                        

                        connection.Execute("InsertInfromacionet", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public List<Models.GetInfromacionet> GetInfromacionet()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<Models.GetInfromacionet>("GetInfromacionet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        public void DeleteInfromacionet(int id)
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

                        connection.Execute("DeleteInfromacionet", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public void UpdateInfromacionet(int? id, string title, string description, int? lineId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new Dapper.DynamicParameters();
                        parameters.Add("@Id", id);
                        parameters.Add("@Titulli", title);
                        parameters.Add("@Pershkrimi", description);
                        



                        connection.Execute("UpdateInfromacionet", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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
