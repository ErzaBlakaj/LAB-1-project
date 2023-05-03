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
    public class InfromacionetController
    {
        private InfromacionetService _InfromacionetService;

        public InfromacionetController(IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("ConnectionString");

            _InfromacionetService = new InfromacionetService(connectionString);
        }
        [HttpPost("InsertInfromacionet")]
        public string InsertNjoftimetEndPoint([FromBody] Infromacionet infromacionet)
        {

            try
            {
                _InfromacionetService.InsertInfromacionet(infromacionet.Titulli, infromacionet.Pershkrimi);

                return "Informacioni u  krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpDelete("InfromacionetById")]
        public string DeleteNjoftimById([FromQuery] int infromacionetId)
        {
            try
            {
                _InfromacionetService.DeleteInfromacionet(infromacionetId);

                return "Informacioni u fshi  me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("getAllInfromacionet")]
        public List<GetNjoftimet> GetAllInfromacionet()
        {
            try
            {

                return InfromacionetService.GetInfromacionet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("updateInfromacionetById")]
        public string UpdateInfromacionetById([FromBody] Infromacionet infromacionet)
        {
            try
            {
                _InfromacionetService.InsertInfromacionet(infromacionet.Titulli, infromacionet.Pershkrimi);

                return "Infromacioni u perditesua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }

}
