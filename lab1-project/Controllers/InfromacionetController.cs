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

                return "Njoftimi u  krijua me sukses!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }

}
