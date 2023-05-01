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
    public class StacionetController
    {
        private StacioniService _stacioniService;

        public StacionetController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _stacioniService = new StacioniService(connectionString);
        }


        //POST - insertim from body
        //GET - marrje from query
        //DELETE - per fshijre 
        //PUT - update 

        [HttpPost("StacioniInsert")]
        public string InsertStcionetEndPoint([FromBody] Stacioni stacioni)
        {
            try
            {
                _stacioniService.InsertStacioni(stacioni.Emri, stacioni.Adresa, stacioni.Latitude, stacioni.Longitude, stacioni.Kodi_Postal);

                return "Stacioni u shtua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("deleteStacioninById")]
        public string DeleteStacioninById([FromQuery] int stacioniId)
        {
            try
            {
                _stacioniService.DeleteStacioniById(stacioniId);

                return "Stacioni u fshij me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet("getAllStacionet")]
        public List<GetStacionet> GetAllStacionet()
        {
            try
            {
                //List<GetShitjet> shitjet = _shitjetService.GetShitjet();

                //return shitjet;

                return _stacioniService.GetStacionet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("updateStacioninById")]
        public string UpdateStacioninById([FromBody] Stacioni stacioni)
        {
            try
            {
                _stacioniService.UpdateStacioninById(stacioni.Id, stacioni.Emri, stacioni.Adresa, stacioni.Latitude, stacioni.Longitude, stacioni.Kodi_Postal);

                return "Stacioni u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

