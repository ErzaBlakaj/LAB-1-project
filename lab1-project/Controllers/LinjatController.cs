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
    public class LinjatController
    {
        private LinjatService _linjatService;

        public LinjatController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _linjatService = new LinjatService(connectionString);
        }


        //POST - insertim from body
        //GET - marrje from query
        //DELETE - per fshijre 
        //PUT - update 

        [HttpPost("insertLinjat")]
        public string InsertLinjatEndPoint([FromBody] Linjat linjat)
        {
            try
            {
                _linjatService.InsertLinjat(linjat.Id, linjat.Emri, linjat.Rruga, linjat.Ndalesat, linjat.Kohezgjatja);

                return "Linja u krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("deleteLinjatById")]
        public string DeleteLinjatById([FromQuery] int linjaId)
        {
            try
            {
                _linjatService.DeleteLinjatById(linjaId);

                return "Linja u fshij me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet("getAllLinjat")]
        public List<GetLinjat> GetAllLinjat()
        {
            try
            {

                return _linjatService.GetLinjat();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("updateLinjenById")]
        public string UpdateLinjenById([FromBody] Linjat linjat)
        {
            try
            {
                _linjatService.UpdateLinjenById(linjat.Id, linjat.Emri, linjat.Rruga, linjat.Ndalesat, linjat.Kohezgjatja);

                return "Linja u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
