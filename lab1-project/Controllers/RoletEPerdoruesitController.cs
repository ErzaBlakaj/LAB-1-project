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
	public class RoletEPerdorueseveController
	{
		private RoletEPerdorueseveService _roletEPerdorueseveService;

		public RoletEPerdorueseveController(IConfiguration configuration)
		{
			string connectionString = configuration.GetValue<string>("ConnectionString");

			_roletEPerdorueseveService = new RoletEPerdorueseveService(connectionString);
		}


		//POST - insertim from body
		//GET - marrje from query
		//DELETE - per fshijre 
		//PUT - update 

		[HttpPost("insertRoletEPerdorueseve")]
		public string InsertRoletEPerdorueseveEndPoint([FromBody] RoletEPerdorueseve RoletEPerdorueseve)
		{
			try
			{
				_roletEPerdorueseveService.InsertRoletEPerdorueseve(RoletEPerdorueseve.Id, RoletEPerdorueseve.Emri_i_rolit);

				return "Rolet E Perdorueseve u krijuan me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		[HttpDelete("deleteRoletEPerdorueseveById")]
		public string DeleteRoletEPerdorueseveById([FromQuery] int RoletEPerdorueseveId)
		{
			try
			{
				_roletEPerdorueseveService.DeleteRoletEPerdorueseveById(RoletEPerdorueseveId);

				return "Rolet E Perdorueseve u fshine me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}


		[HttpGet("getAllRoletEPerdorueseve")]
		public List<GetRoletEPerdorueseve> GetAllRoletEPerdorueseve()
		{
			try
			{


				return _roletEPerdorueseveService.GetRoletEPerdorueseve();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut("updateRoletEPerdorueseveById")]
		public string UpdateRoletEPerdorueseveById([FromBody] RoletEPerdorueseve RoletEPerdorueseve)
		{
			try
			{
				_roletEPerdorueseveService.UpdateRoletEPerdorueseveById(RoletEPerdorueseve.Id, RoletEPerdorueseve.Emri_i_rolit);

				return "Rolet E Perdorueseve u perditesuan me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
}
