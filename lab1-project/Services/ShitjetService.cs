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
    public class ShitjetService
    {
        private string _connectionString { get; set; }

        public ShitjetService( string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertShitjet(int? menyraPagesesId, int? promokodiId, int? sasia, int? klientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open(); //hapet koneksioni me databaz

                using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
                {
                    try
                    {
                        connection.Execute("ShitjetInsert", new { Menyra_pageses_Id = menyraPagesesId, Promokodi_Id = promokodiId, Sasia = sasia, KlientId = klientId }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public void DeleteShitjetById(int id)
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

                        connection.Execute("ShitjetDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

        public List<GetShitjet> GetShitjet()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<GetShitjet>("ShitjetGet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public void UpdateShitjenById(int? id, int? menyraPagesesId, int? promokodiId, int? sasia, int? klientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute("ShitjetUpdate",
                            new
                            {
                                Id = id,
                                Menyra_pageses_Id = menyraPagesesId,
                                Promokodi_Id = promokodiId,
                                Sasia = sasia,
                                KlientId = klientId
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
