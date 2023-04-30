using Dapper;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1_project.Services
{
    public class FeedbackService
    {

        private string _connectionString { get; set; }

        public FeedbackService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void InsertFeedback(string username, string comment, int rating, int lineId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new Dapper.DynamicParameters();
                        parameters.Add("@Emri_Perdoruesit", username);
                        parameters.Add("@Komenti", comment);
                        parameters.Add("@Vleresimi", rating);
                        parameters.Add("@Id_Linjat", lineId);

                        connection.Execute("InsertFeedback", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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
        public void DeleteFeedback(int feedbackId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@FeedbackId", feedbackId);

                        connection.Execute("DeleteFeedback", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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

        public List<Models.GetFeedbacks> GetFeedbacks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query<Models.GetFeedbacks>("FeedbackGet", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public void UpdateFeedback(int feedbackId, string comment, int rating)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@FeedbackId", feedbackId);
                        parameters.Add("@Komenti", comment);
                        parameters.Add("@Vleresimi", rating);

                        connection.Execute("UpdateFeedback", parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

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

        internal void DeleteFeedbackById(int feedbackId)
        {
            throw new NotImplementedException();
        }

        internal void UpdateFeedbackById(object id, object menyra_pageses_Id, object promokodi_Id, object sasia, object klientId)
        {
            throw new NotImplementedException();
        }

        internal void UpdateFeedbackById(string emri_Perdoruesit, string komenti, int vleresimi, int id_Linjat)
        {
            throw new NotImplementedException();
        }
    }
}




