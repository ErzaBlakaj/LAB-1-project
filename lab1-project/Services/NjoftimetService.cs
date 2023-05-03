using Dapper;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using lab1_project.Models;


namespace lab1_project.Services
{
    public class NjoftimetService
    {
        private string _connectionString { get; set; }

        public NjoftimetService(string connectionString)
        {
            _connectionString = connectionString;

        }

        public void InsertNjoftimet(string title, string description, int? lineId)
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
                        parameters.Add("@Id_Linjat", lineId);

                        connection.Execute("InsertNjoftim", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public List<Models.GetNjoftimet> GetNjoftimet()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<Models.GetNjoftimet>("GetNjoftimet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public void DeleteNjoftimet(int id)
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

                        connection.Execute("DeleteNjoftim", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                        transaction.Commit();
                    
                    }catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void UpdateNjoftimet(int? id,string title, string description, int? lineId)
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
                        parameters.Add("@Id_Linjat", lineId);



                        connection.Execute("UpdateNjoftim", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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

