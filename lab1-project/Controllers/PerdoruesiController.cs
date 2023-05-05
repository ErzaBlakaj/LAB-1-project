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
	public class PerdoruesiController
	{
		private PerdoruesiService _perdoruesiService;

		public PerdoruesiController(IConfiguration configuration)
		{
			string connectionString = configuration.GetValue<string>("ConnectionString");

			_perdoruesiService = new PerdoruesiService(connectionString);
		}


		//POST - insertim from body
		//GET - marrje from query
		//DELETE - per fshijre 
		//PUT - update 

		[HttpPost("insertPerdoruesi")]
		public string InsertPerdoruesiEndPoint([FromBody] Perdoruesi Perdoruesi)
		{
			try
			{
				_perdoruesiService.InsertPerdoruesi(Perdoruesi.Emri, Perdoruesi.Mbiemri, Perdoruesi.Email, Perdoruesi.Fjalekalimi, Perdoruesi.Id_role);

				return "Perdoruesi u krijua me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		[HttpDelete("deletePerdoruesiById")]
		public string DeletePerdoruesiById([FromQuery] int PerdoruesiId)
		{
			try
			{
				_perdoruesiService.DeletePerdoruesiById(PerdoruesiId);

				return "Perdoruesi u fshi me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}


		[HttpGet("getAllPerdoruesi")]
		public List<GetPerdoruesi> GetAllPerdoruesi()
		{
			try
			{


				return _perdoruesiService.GetPerdoruesi();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut("updatePerdoruesiById")]
		public string UpdatePerdoruesiById([FromBody] Perdoruesi Perdoruesi)
		{
			try
			{
				_perdoruesiService.UpdatePerdoruesiById(Perdoruesi.Id, Perdoruesi.Emri, Perdoruesi.Mbiemri, Perdoruesi.Email, Perdoruesi.Fjalekalimi, Perdoruesi.Id_role);

				return "Perdoruesi u perditesua me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
}

