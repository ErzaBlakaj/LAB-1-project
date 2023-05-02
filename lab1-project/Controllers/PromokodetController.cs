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
	public class PromokodetController
	{
		private PromokodetService _PromokodetService;

		public PromokodetController(IConfiguration configuration)
		{
			string connectionString = configuration.GetValue<string>("ConnectionString");

			_PromokodetService = new PromokodetService(connectionString);
		}


		//POST - insertim from body
		//GET - marrje from query
		//DELETE - per fshijre 
		//PUT - update 

		[HttpPost("insertRoletEPerdorueseve")]
		public string InsertRoletEPerdorueseveEndPoint([FromBody] Promokodet Promokodet)
		{
			try
			{
				_PromokodetService.InsertPromokodet(Promokodet.Id, Promokodet.Kodi_promocional, Promokodet.Zbritja, Promokodet.Data_skadimit, Promokodet.DataERegjistrimit);

				return "Promokodet u krijuan me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		[HttpDelete("deletePromokodetById")]
		public string DeletePromokodetById([FromQuery] int PromokodetId)
		{
			try
			{
				_PromokodetService.DeletePromokodetById(PromokodetId);

				return "Promokodet u fshine me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}


		[HttpGet("getAllPromokodet")]
		public List<GetPromokodet> GetAllPromokodet()
		{
			try
			{


				return _PromokodetService.GetPromokodet();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[HttpPut("updatePromokodetById")]
		public string UpdatePromokodetById([FromBody] Promokodet Promokodet)
		{
			try
			{
				_PromokodetService.UpdatePromokodetById(Promokodet.Id, Promokodet.Kodi_promocional, Promokodet.Zbritja, Promokodet.Data_skadimit, Promokodet.DataERegjistrimit);

				return "Promokodet u perditesuan me sukses!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

	}
}
