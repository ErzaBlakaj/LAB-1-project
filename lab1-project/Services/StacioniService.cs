
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
    public class StacioniService
    {
        private string _connectionString { get; set; }

        public StacioniService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void StacioniInsert(String? Emri, String? Adresa, float? Latitude, float? Longitude, decimal? KodiPostal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open(); //hapet koneksioni me databaz

                using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
                {
                    try
                    {
                        connection.Execute("StacioniInsert", new { Emri = Emri, Adresa = Adresa, Latitude = Latitude, Longitude = Longitude, Kodi_Postal = KodiPostal }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public void DeleteStacioniById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@Id", Id);

                        connection.Execute("StacioniDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

        public List<GetStacionet> GetStacionet()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<GetStacionet>("StacionetGet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public void UpdateStacioninById(int? Id, String? Emri, String? Adresa, float? Latitude, float? Longitude, decimal? KodiPostal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute("StacionetUpdate",
                            new
                            {
                                Id = Id,
                                Emri = Emri,
                                Adresa = Adresa,
                                Latitude = Latitude,
                                Longitude = Longitude,
                                Kodi_Postal = KodiPostal
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
