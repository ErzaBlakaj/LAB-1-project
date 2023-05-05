using lab1_project.Models;
using lab1_project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace lab1_project.Controllers
{
	[Route("/api/[controller]")]
	[ApiController]
	public class OraretController
	{
		private OraretService _oraretService;

		public OraretController(IConfiguration configuration)
		{
			string connectionString = configuration.GetValue<string>("ConnectionString");

			_oraretService = new OraretService(connectionString);
		}


		//POST - insertim from body
		//GET - marrje from query
		//DELETE - per fshijre 
		//PUT - update 

		[HttpPost("insertOraret")]
		public string InsertOraretEndPoint([FromBody] Oraret oraret)
		{
			try
			{
				_oraretService.InsertOraret(oraret.Emri_i_linjes, oraret.Numri_i_orarit, oraret.Ora_e_nisjes, oraret.Ora_e_mberritjes, oraret.stacioni_i_nisjes, oraret.stacioni_i_mberritjes, oraret.Id_Linjat);

				return "Orari u krijua me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		[HttpDelete("deleteOrarinById")]
		public string DeleteOrarinById([FromQuery] int oraretId)
		{
			try
			{
				_oraretService.DeleteOraretById(oraretId);

				return "Orari u fshij me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}


		[HttpGet("getAllOraret")]
		public List<GetOraret> GetAllOraret()
		{
			try
			{
				//List<GetOraret> oraret = _oraretService.GetOraret();

				//return oraret;

				return _oraretService.GetOraret();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut("updateOraretById")]
		public string UpdateOraretById([FromBody] Oraret oraret)
		{
			try
			{
				_oraretService.UpdateOraretById(oraret.Id, oraret.Emri_i_linjes, oraret.Numri_i_orarit, oraret.Ora_e_nisjes, oraret.Ora_e_mberritjes, oraret.stacioni_i_nisjes, oraret.stacioni_i_mberritjes, oraret.Id_Linjat);


				return "Orari u perditesua me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
}

