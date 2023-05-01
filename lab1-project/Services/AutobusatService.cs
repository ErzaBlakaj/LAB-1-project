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
    public class AutobusatService
    {
        private string _connectionString { get; set; }

        public AutobusatService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertAutobusat(string? Pershkrimi, string? Targat, DateTime? Dataeregjistrimit, DateTime? Dataeskadimitteregjistrimit, string? Nrshasise)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open(); //hapet koneksioni me databaz

                using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
                {
                    try
                    {
                        connection.Execute("InsertAutobusat", new {Pershkrimi = Pershkrimi, Targat = Targat, DataERegjistrimit = Dataeregjistrimit, DataESkadimitTeRegjistrimit = Dataeskadimitteregjistrimit,  Nrshasise = Nrshasise }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public void DeleteAutobusatById(int id)
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

                        connection.Execute("AutobusatDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

        public List<GetAutobusat> GetAutobusat()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<GetAutobusat>("AutobusatGet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public void UpdateAutobusatById(int? id, string? Pershkrimi, string? Targat, DateTime? Dataeregjistrimit, DateTime? Dataeskadimitteregjistrimit, string? Nrshasise)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute("AutobusatUpdate",
                            new
                            {
                                Id = id,
                                Pershkrimi = Pershkrimi,
                                Targat = Targat,
                                DataERegjistrimit = Dataeregjistrimit,
                                DataESkadimitTeRegjistrimit = Dataeskadimitteregjistrimit,
                                NrShasise = Nrshasise
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