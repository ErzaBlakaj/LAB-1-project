using Dapper;
using lab1_project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace lab1_project.Services
{
	public class OraretService
	{
		private string _connectionString;

		private string connectionString { get; set; }
		public OraretService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void InsertOraret(int? Id, string? EmriIlinjes, int? NumriIOrarit, TimeSpan? OraENisjes, TimeSpan? OraEMberritjes, string? StacioniINisjes, string? StacioniIMberritjes, int? IdLinjat)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open(); //hapet koneksioni me databaz

				using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
				{
					try
					{
						connection.Execute("OraretInsert", new { Id = Id, Emri_i_linjes = EmriIlinjes, Numri_i_orarit = NumriIOrarit, Ora_e_nisjes = OraENisjes, Ora_e_mberritjes = OraEMberritjes, Stacioni_i_nisjes = StacioniINisjes, Stacioni_i_mberritjes = StacioniIMberritjes, Id_linjat = IdLinjat }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
		public void DeleteOraretById(int Id)
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

						connection.Execute("OraretDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

		public List<GetOraret> GetOraret()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var result = connection.Query<GetOraret>("OraretGet", commandType: CommandType.StoredProcedure);

				return result.ToList();
			}
		}
		public void UpdateOraretById(int? Id, string? EmriIlinjes, int? NumriIOrarit, TimeSpan? OraENisjes, TimeSpan? OraEMberritjes, string? StacioniINisjes, string? StacioniIMberritjes, int? IdLinjat)

		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						connection.Execute("OraretUpdate",
							new
							{
								Id = Id,
								Emri_i_injes = EmriIlinjes,
								Numri_i_orarit = NumriIOrarit,
								Ora_e_nisjes = OraENisjes,
								Ora_e_mberritjes = OraEMberritjes,
								Stacioni_i_nisjes = StacioniINisjes,
								Stacioni_i_mberritjes = StacioniIMberritjes,
								Id_linjat = IdLinjat


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

		internal void InsertOraret(string emri_i_linjes, int? numri_i_orarit, TimeSpan? ora_e_nisjes, TimeSpan? ora_e_mberritjes, string stacioni_i_nisjes, string stacioni_i_mberritjes, int? id_Linjat)
		{
			throw new NotImplementedException();
		}

		internal void UpdateOraretById(string emri_i_linjes, int? numri_i_orarit, TimeSpan? ora_e_nisjes, TimeSpan? ora_e_mberritjes, string stacioni_i_nisjes, string stacioni_i_mberritjes, int? id_Linjat)
		{
			throw new NotImplementedException();
		}
	}
}



