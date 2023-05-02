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
	public class PromokodetService
	{
		private string _connectionString { get; set; }

		public PromokodetService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void InsertPromokodet(int? Id, string? KodiPromocional, float? Zbritja, DateTime? Data_skadimit, DateTime? DataERegjistrimit)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open(); //hapet koneksioni me databaz

				using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
				{
					try
					{
						connection.Execute("PromokodetInsert", new { Id = Id, Kodi_promocional = KodiPromocional, Zbrita = Zbritja, Data_skadimit = Data_skadimit, DataERegjistrimit = DataERegjistrimit }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
		public void DeletePromokodetById(int id)
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

						connection.Execute("PromokodetDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

		public List<GetPromokodet> GetPromokodet()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var result = connection.Query<GetPromokodet>("Promokodet", commandType: CommandType.StoredProcedure);

				return result.ToList();
			}
		}

		public void UpdatePromokodetById(int? Id, string? Kodi_promocional, float? Zbritja, DateTime? Data_skadimit, DateTime? DataERegjistrimit)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						connection.Execute("Promokodet",
							new
							{
								Id = Id,
								Kodi_promocional = Kodi_promocional,
								Zbritja = Zbritja,
								Data_skadimit = Data_skadimit,
								DataERegjistrimit = DataERegjistrimit


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

