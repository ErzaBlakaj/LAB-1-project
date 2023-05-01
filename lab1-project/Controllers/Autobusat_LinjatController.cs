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
    public class Autobusat_LinjatController
    {
        private Autobusat_LinjatService _autobusat_LinjatService;

        public Autobusat_LinjatController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _autobusat_LinjatService = new Autobusat_LinjatService(connectionString);
        }


        //POST - insertim from body
        //GET - marrje from query
        //DELETE - per fshijre 
        //PUT - update 

        [HttpPost("insertAutobusat_Linjat")]
        public string InsertAutobusat_LinjatEndPoint([FromBody] Autobusat_Linjat autobusat_linjat)
        {
            try
            {
                _autobusat_LinjatService.InsertAutobusat_Linjat(autobusat_linjat.Id, autobusat_linjat.AutobusiId, autobusat_linjat.LinjatId);

                return "Autobsi_Linjat u krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("deleteAuobusat_LinjatById")]
        public string DeleteAutobusat_LinjatById([FromQuery] int autobusiId)
        {
            try
            {
                _autobusat_LinjatService.DeleteAutobusat_LinjatById(autobusiId);

                return "Autobusi_Linjat u fshij me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet("getAllAutobusat_Linjat")]
        public List<GetAutobusat_Linjat> GetAllAutobusat_Linjat()
        {
            try
            {

                return _autobusat_LinjatService.GetAutobusat_Linjat();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("updateAutobusin_LinjatById")]
        public string UpdateAutobusin_LinjatById([FromBody] Autobusat_Linjat autobusat_linjat)
        {
            try
            {
                _autobusat_LinjatService.UpdateAutobusat_LinjatById(autobusat_linjat.Id, autobusat_linjat.AutobusiId, autobusat_linjat.LinjatId);

                return "Autobusi_Linjat u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
