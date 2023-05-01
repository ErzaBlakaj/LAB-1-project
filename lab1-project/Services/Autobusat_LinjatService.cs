using Dapper;
using lab1_project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace lab1_project.Services
{
    public class Autobusat_LinjatService
    {
        private string _connectionString { get; set; }

        public Autobusat_LinjatService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertAutobusat_Linjat(int? autobusiid, int? linjatid)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open(); //hapet koneksioni me databaz

                using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
                {
                    try
                    {
                        connection.Execute("InsertAutobusat_Linjat", new {AutobusiId = autobusiid, LinjatId = linjatid }, commandType: CommandType.StoredProcedure, transaction: transaction);

                        transaction.Commit(); //nese gjithcka eshte okej kjo behet commit edhe ruhen te dhenat ne db
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // nese deshton e ben rollback
                        throw ex;
                    }
                }
            }
        }
        public void DeleteAutobusat_LinjatById(int id)
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

                        connection.Execute("Autobusat_LinjatDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public List<GetAutobusat_Linjat> GetAutobusat_Linjat()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<GetAutobusat_Linjat>("Autobusat_LinjatGet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public void UpdateAutobusat_LinjatById(int? id, int? autobusiid, int? linjatid)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute("Autobusat_LinjatUpdate",
                            new
                            {
                                Id = id,
                                AutobusiId = autobusiid,
                                LinjatId = linjatid
                            },
                            commandType: CommandType.StoredProcedure,
                            transaction: transaction);

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
