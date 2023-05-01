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
    public class AutobusatController
    {
        private AutobusatService _autobusatService;

        public AutobusatController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _autobusatService = new AutobusatService(connectionString);
        }


        //POST - insertim from body
        //GET - marrje from query
        //DELETE - per fshijre 
        //PUT - update 

        [HttpPost("InsertAutobusat")]
        public string InsertAutobusatEndPoint([FromBody] Autobusat autobusat)
        {
            try
            {
                _autobusatService.InsertAutobusat(autobusat.Pershkrimi, autobusat.Targat, autobusat.DataERegjistrimit, autobusat.DataESkadimitTeRegjistrimit, autobusat.NrShasise);

                return "Autobusi u krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpDelete("deleteAuobusatById")]
        public string DeleteAutobusatById([FromQuery] int autobusiId)
        {
            try
            {
                _autobusatService.DeleteAutobusatById(autobusiId);

                return "Autobusi u fshij me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpGet("getAllAutobusat")]
        public List<GetAutobusat> GetAllAutobusat()
        {
            try
            {

                return _autobusatService.GetAutobusat();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("updateAutobusinById")]
        public string UpdateAutobusinById([FromBody] Autobusat autobusat)
        {
            try
            {
                _autobusatService.UpdateAutobusatById(autobusat.Id, autobusat.Pershkrimi, autobusat.Targat, autobusat.DataERegjistrimit, autobusat.DataESkadimitTeRegjistrimit, autobusat.NrShasise);

                return "Autobusi u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
