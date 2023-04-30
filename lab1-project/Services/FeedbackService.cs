using Dapper;
using System.Data.SqlClient;
using System.Data;
using System;

namespace lab1_project.Services
{
    public class FeedbackService
    {

        private string _connectionString { get; set; }

        public FeedbackService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void InsertFeedback(string emriPerdoruesit, string komenti, int vleresimi, int idLinjat, string connectionString)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add("@Emri_Perdoruesit", emriPerdoruesit, DbType.String, size: 255);
                        parameters.Add("@Komenti", komenti, DbType.String, size: -1);
                        parameters.Add("@Vleresimi", vleresimi, DbType.Int32);
                        parameters.Add("@Id_Linjat", idLinjat, DbType.Int32);

                        connection.Execute(
                            "InsertFeedback",
                            parameters,
                            transaction: transaction,
                            commandType: CommandType.StoredProcedure
                        );

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Failed to insert feedback.", ex);
                    }
                }
            }
        }


    }
}
