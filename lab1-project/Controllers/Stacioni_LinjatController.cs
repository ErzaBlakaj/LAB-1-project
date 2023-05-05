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
    public class Stacioni_LinjatController
    {
        private Stacioni_LinjatService _stacioni_LinjatService;

        public Stacioni_LinjatController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _stacioni_LinjatService = new Stacioni_LinjatService(connectionString);
        }


        //POST - insertim from body
        //GET - marrje from query
        //DELETE - per fshijre 
        //PUT - update 

        [HttpPost("insertStacioni_Linjat")]
        public string InsertStacioni_LinjatEndPoint([FromBody] Stacioni_Linjat stacioni_Linjat)
        {
            try
            {
                _stacioni_LinjatService.InsertStacioni_Linjat(stacioni_Linjat.Id, stacioni_Linjat.StacioniId, stacioni_Linjat.LinjatId);

                return "Stacioni_Linjat u krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("deleteStacioni_LinjatById")]
        public string DeleteStacioni_LinjatById([FromQuery] int stacioniId)
        {
            try
            {
                _stacioni_LinjatService.DeleteStacioni_LinjatById(stacioniId);

                return "Stacioni_Linjat u fshij me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet("getAllStacioni_Linjat")]
        public List<GetStacioni_Linjat> GetAllStacioni_Linjat()
        {
            try
            { 
                return _stacioni_LinjatService.GetStacioni_Linjat();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("updateStacioni_LinjatById")]
        public string UpdateStacioni_LinjatById([FromBody] Stacioni_Linjat stacioni_Linjat)
        {
            try
            {
                _stacioni_LinjatService.UpdateStacioni_LinjatById(stacioni_Linjat.Id, stacioni_Linjat.StacioniId, stacioni_Linjat.LinjatId);

                return "Stacioni_Linjat u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}

