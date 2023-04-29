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
    public class ShitjetController
    {
        private ShitjetService _shitjetService;

        public ShitjetController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _shitjetService = new ShitjetService(connectionString);
        }


        //POST - insertim from body
        //GET - marrje from query
        //DELETE - per fshijre 
        //PUT - update 

        [HttpPost("insertShitjet")]
        public string InsertShitjetEndPoint([FromBody] Shitjet shitjet)
        {
            try
            {
                _shitjetService.InsertShitjet(shitjet.Menyra_pageses_Id,shitjet.Promokodi_Id,shitjet.Sasia,shitjet.KlientId);

                return "Shitja u krijua me sukses!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("deleteShitjenById")]
        public string DeleteShitjenById([FromQuery] int shitjaId)
        {
            try
            {
                _shitjetService.DeleteShitjetById(shitjaId);

                return "Shitja u fshij me sukses!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet("getAllShitjet")]
        public List<GetShitjet> GetAllShitjet()
        {
            try
            {
                //List<GetShitjet> shitjet = _shitjetService.GetShitjet();

                //return shitjet;

                return _shitjetService.GetShitjet();
            }
            catch(Exception ex )
            {
                throw ex;
            }
        }

        [HttpPut("updateShitjenById")]
        public string UpdateShitjenById([FromBody] Shitjet shitja)
        {
            try
            {
                _shitjetService.UpdateShitjenById(shitja.Id, shitja.Menyra_pageses_Id, shitja.Promokodi_Id, shitja.Sasia, shitja.KlientId);

                return "Shitja u perditesua me sukses!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
