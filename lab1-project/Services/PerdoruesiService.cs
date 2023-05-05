

using Dapper;
using lab1_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace lab1_project.Services
{
	public class PerdoruesiService
	{
		private string _connectionString { get; set; }

		public PerdoruesiService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void InsertPerdoruesi(string? Emri, string? Mbiemri, string? Email, string? Fjalekalimi, int? IdRole)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open(); //hapet koneksioni me databaz

				using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
				{
					try
					{
						connection.Execute("PerdoruesiInsert", new {Emri = Emri, Mbiemri = Mbiemri, Email = Email, Fjalekalimi = Fjalekalimi, Id_role = IdRole }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
		public void DeletePerdoruesiById(int id)
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

						connection.Execute("PerdoruesiDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

		public List<GetPerdoruesi> GetPerdoruesi()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var result = connection.Query<GetPerdoruesi>("PerdoruesiGet", commandType: CommandType.StoredProcedure);

				return result.ToList();
			}
		}

		public void UpdatePerdoruesiById(int? Id, string? Emri, string? Mbiemri, string? Email, string? Fjalekalimi, int IdRole)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						connection.Execute("PerdoruesiUpdate",
							new
							{
								Id = Id,
								Emri = Emri,
								Mbiemri = Mbiemri,
								Email = Email,
								Fjalekalimi = Fjalekalimi,
								Id_role = IdRole


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

		internal void UpdatePerdoruesiById(int? id, string emri, string mbiemri, string email, string fjalekalimi, int? id_role)
		{
			throw new NotImplementedException();
		}
	}
}
