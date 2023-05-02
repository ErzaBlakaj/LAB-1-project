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
	public class RoletEPerdorueseveService
	{
		private string _connectionString { get; set; }

		public RoletEPerdorueseveService(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void InsertRoletEPerdorueseve(int? Id, string? EmriIRolit)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open(); //hapet koneksioni me databaz

				using (var transaction = connection.BeginTransaction()) //hapet nje transaction 
				{
					try
					{
						connection.Execute("RoletEPerdorueseveInsert", new { Id = Id, Emri_i_rolit = EmriIRolit }, commandType: CommandType.StoredProcedure, transaction: transaction);

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
		public void DeleteRoletEPerdorueseveById(int id)
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

						connection.Execute("RoletEPerdorueseveDelete", parameters, transaction, commandType: CommandType.StoredProcedure);

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

		public List<GetRoletEPerdorueseve> GetRoletEPerdorueseve()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				var result = connection.Query<GetRoletEPerdorueseve>("RoletEPerdorueseveGet", commandType: CommandType.StoredProcedure);

				return result.ToList();
			}
		}

		public void UpdateRoletEPerdorueseveById(int? Id, string EmriIRolit)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						connection.Execute("RoletEPerdorueseveUpdate",
							new
							{
								Id = Id,
								Emri_i_rolit = EmriIRolit

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
