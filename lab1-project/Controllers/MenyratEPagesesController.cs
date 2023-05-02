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
	public class MenyratEPagesesController
	{
		private MenyratEPagesesService _MenyratEPagesesService;

		public MenyratEPagesesController(IConfiguration configuration)
		{
			string connectionString = configuration.GetValue<string>("ConnectionString");

			_MenyratEPagesesService = new MenyratEPagesesService(connectionString);
		}


		//POST - insertim from body
		//GET - marrje from query
		//DELETE - per fshijre 
		//PUT - update 

		[HttpPost("insertMenyratEPageses")]
		public string InsertMenyratEPagesesEndPoint([FromBody] MenyratEPageses MenyratEPageses)
		{
			try
			{
				_MenyratEPagesesService.InsertMenyratEPageses(MenyratEPageses.Id, MenyratEPageses.Pershkrimi);

				return "Menyrat E Pageses u krijuan me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		[HttpDelete("deleteMenyratEPagesesById")]
		public string DeleteMenyratEPagesesById([FromQuery] int MenyratEPagesesId)
		{
			try
			{
				_MenyratEPagesesService.DeleteMenyratEPagesesById(MenyratEPagesesId);

				return "Menyrat E Pageses u fshine me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}


		[HttpGet("getAllMenyratEPageses")]
		public List<GetMenyratEPageses> GetAllMenyratEPageses()
		{
			try
			{


				return _MenyratEPagesesService.GetMenyratEPageses();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut("updateMenyratEPagesesById")]
		public string UpdateMenyratEPagesesById([FromBody] MenyratEPageses MenyratEPageses)
		{
			try
			{
				_MenyratEPagesesService.UpdateMenyratEPagesesById(MenyratEPageses.Id, MenyratEPageses.Pershkrimi);

				return "Menyrat E Pageses u perditesuan me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
}
