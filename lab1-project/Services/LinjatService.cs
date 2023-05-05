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
    public class LinjatService
    {
        private string _connectionString { get; set; }

        public LinjatService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertLinjat(int? id, string? Emri, string? Rruga, string? Ndalesat, TimeSpan? Kohezgjatja)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open(); //hapet koneksioni me databaz

                using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
                {
                    try
                    {
                        connection.Execute("LinjatInsert", new { Id=id,Emri = Emri, Rruga = Rruga, Ndalesat = Ndalesat, Kohezgjatja = Kohezgjatja }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public void DeleteLinjatById(int id)
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

                        connection.Execute("LinjatDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

        public List<GetLinjat> GetLinjat()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<GetLinjat>("LinjatGet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public void UpdateLinjenById(int? id, string? Emri, string? Rruga, string? Ndalesat, TimeSpan? Kohezgjatja)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute("LinjatUpdate",
                            new
                            {
                                Id = id,
                                Emri = Emri,
                                Rruga = Rruga,
                                Ndalesat = Ndalesat,
                                Kohezgjatja = Kohezgjatja
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
